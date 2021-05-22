﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Spice.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext db;

        public OrdersController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        [Authorize]
        public async Task<IActionResult> Confirm(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            OrderDetailsViewModel orderDetailsVM = new OrderDetailsViewModel()
            {
                OrderHeader = await db.OrderHeaders.Include(m => m.ApplicationUser).
                              FirstOrDefaultAsync(m => m.UserId == claim.Value && m.Id == id),
                OrderDetails = await db.OrderDetails.Where(m => m.OrderId == id).ToListAsync()
            };

            return View(orderDetailsVM);
        }

        private int pageSize = 2;
        [Authorize]
        public async Task<IActionResult> OrderHistory(int pageNumber = 1)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //List<OrderDetailsViewModel> orderDetailsVMList = new List<OrderDetailsViewModel>();

            OrderListViewModel orderListVM = new OrderListViewModel()
            {
                Orders = new List<OrderDetailsViewModel>()
            };

            List<OrderHeader> orderHeadersList;
            if (User.IsInRole(SD.ManagerUser))
            {
                orderHeadersList = await db.OrderHeaders.ToListAsync();
            }
            else
            {
                orderHeadersList = await db.OrderHeaders.Include(m => m.ApplicationUser)
                                                .Where(m => m.UserId == claim.Value).ToListAsync();
            }


            foreach (var orderHeader in orderHeadersList)
            {
                OrderDetailsViewModel orderDetailsVM = new OrderDetailsViewModel()
                {
                    OrderHeader = orderHeader,
                    OrderDetails = await db.OrderDetails.Where(m => m.OrderId == orderHeader.Id).ToListAsync()
                };

                orderListVM.Orders.Add(orderDetailsVM);
            }

            var count = orderListVM.Orders.Count;
            orderListVM.Orders = orderListVM.Orders.OrderByDescending(o => o.OrderHeader.Id)
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize).ToList();

            orderListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = pageNumber,
                RecordsPerPage = pageSize,
                TotalRecords = count,
                UrlParam = "/Customer/Orders/OrderHistory?pageNumber=:"
            };

            return View(orderListVM);
        }


        public async Task<IActionResult> GetOrderDetails(int id)
        {
            OrderDetailsViewModel orderDetailsVM = new OrderDetailsViewModel()
            {
                OrderHeader = await db.OrderHeaders.Include(m => m.ApplicationUser)
                                .FirstOrDefaultAsync(m => m.Id == id),
                OrderDetails = await db.OrderDetails.Where(m => m.OrderId == id).ToListAsync()
            };

            return PartialView("_IndividualOrderDetails", orderDetailsVM);
        }

        public async Task<IActionResult> GetOrderStatus(int id)
        {
            OrderHeader orderHeader = await db.OrderHeaders.FindAsync(id);
            return PartialView("_OrderStatus", orderHeader.Status);
        }

        [Authorize(Roles = SD.ManagerUser + "," + SD.KitchenUser)]
        public async Task<IActionResult> OrderManager()
        {

            List<OrderDetailsViewModel> orderDetailsVMList = new List<OrderDetailsViewModel>();

            List<OrderHeader> orderHeadersList = await db.OrderHeaders.Where(o => o.Status == SD.StatusInProcess
                                                || o.Status == SD.StatusSubmitted).ToListAsync();

            foreach (var orderHeader in orderHeadersList)
            {
                OrderDetailsViewModel orderDetailsVM = new OrderDetailsViewModel()
                {
                    OrderHeader = orderHeader,
                    OrderDetails = await db.OrderDetails.Where(m => m.OrderId == orderHeader.Id).ToListAsync()
                };

                orderDetailsVMList.Add(orderDetailsVM);
            }

            return View(orderDetailsVMList.OrderBy(o => o.OrderHeader.PickUpTime).ToList());
        }


        [Authorize(Roles = SD.ManagerUser + "," + SD.KitchenUser)]
        public async Task<IActionResult> OrderPrepare(int orderId)
        {
            var orderHeader = await db.OrderHeaders.FindAsync(orderId);
            orderHeader.Status = SD.StatusInProcess;

            await db.SaveChangesAsync();

            return RedirectToAction("OrderManager");
        }


        [Authorize(Roles = SD.ManagerUser + "," + SD.KitchenUser)]
        public async Task<IActionResult> OrderReady(int orderId)
        {
            var orderHeader = await db.OrderHeaders.FindAsync(orderId);
            orderHeader.Status = SD.StatusReady;

            await db.SaveChangesAsync();

            return RedirectToAction("OrderManager");
        }


        [Authorize(Roles = SD.ManagerUser + "," + SD.KitchenUser)]
        public async Task<IActionResult> OrderCancel(int orderId)
        {
            var orderHeader = await db.OrderHeaders.FindAsync(orderId);
            orderHeader.Status = SD.StatusCanceled;

            await db.SaveChangesAsync();

            return RedirectToAction("OrderManager");
        }

        [Authorize(Roles = SD.ManagerUser + "," + SD.FrontDeskUser)]
        public async Task<IActionResult> OrderPickup(string SearchEmail, string SearchPhone, string SearchName, int pageNumber = 1)
        {


            OrderListViewModel orderListVM = new OrderListViewModel()
            {
                Orders = new List<OrderDetailsViewModel>()
            };

            StringBuilder param = new StringBuilder();
            param.Append("/Customer/Orders/OrderPickup?pageNumber=:");
            param.Append("&SearchName=");

            if (SearchEmail != null)
            {
                param.Append(SearchEmail);
            }
            else
            {
                SearchEmail = "";
            }

            if (SearchName != null)
            {
                param.Append(SearchName);
            }
            else
            {
                SearchName = "";
            }

            if (SearchPhone != null)
            {
                param.Append(SearchPhone);
            }
            else
            {
                SearchPhone = "";
            }


            List<OrderHeader> orderheaderList = await db.OrderHeaders.Include(m =>m.ApplicationUser).OrderByDescending(o =>o.OrderDate)
                                            .Where(m =>m.Status == SD.StatusReady
                                            && m.ApplicationUser.Name.ToLower().Contains(SearchName.ToLower())
                                            && m.ApplicationUser.Email.ToLower().Contains(SearchEmail.ToLower())
                                            && m.ApplicationUser.PhoneNumber.ToLower().Contains(SearchPhone.ToLower())
                                            ).ToListAsync();


            foreach (var orderHeader in orderheaderList)
            {
                OrderDetailsViewModel orderDetailsVM = new OrderDetailsViewModel()
                {
                    OrderHeader = orderHeader,
                    OrderDetails = await db.OrderDetails.Where(m => m.OrderId == orderHeader.Id).ToListAsync()
                };

                orderListVM.Orders.Add(orderDetailsVM);
            }

            var count = orderListVM.Orders.Count;
            orderListVM.Orders = orderListVM.Orders.OrderByDescending(o => o.OrderHeader.Id)
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize).ToList();

            orderListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = pageNumber,
                RecordsPerPage = pageSize,
                TotalRecords = count,
                UrlParam = param.ToString()
            };

            return View(orderListVM);
        }


        [HttpPost]
        [Authorize(Roles = SD.ManagerUser + "," + SD.FrontDeskUser)]
        public async Task<IActionResult> OrderPickup(int id)
        {
            var orderHeader = await db.OrderHeaders.FindAsync(id);
            orderHeader.Status = SD.StatusCompleted;

            await db.SaveChangesAsync();

            return RedirectToAction("OrderPickup");
        }

    }
}
