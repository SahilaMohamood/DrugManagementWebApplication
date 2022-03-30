using Microsoft.AspNetCore.Mvc;
using DrugManagementWebApp.Data;
using DrugManagementWebApp.Interfaces;
using DrugManagementWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DrugManagementWebApp.Controllers
{
    [Authorize]
    public class ReactionAgentController : Controller
    {
        //Enabling DI

        private readonly IReactionAgent _repository;
        public ReactionAgentController(IReactionAgent repo) //here the rpository will be passed by the dependency injection
        {
            _repository = repo;
        }
        //Read method of the CRUD Operation . It Lists all data from the units table
        public IActionResult Index(string SearchText = "", int pg = 1, int pageSize = 3)
        {
            ViewBag.SearchText = SearchText;

            PaginatedList<ReactionAgent> reactionAgents = _repository.GetItems(SearchText, pg, pageSize);

            //int totRecs = ((PaginatedList<ReactionAgent>)ReactionAgents).TotalRecords;

            var pager = new PagerModel(reactionAgents.TotalRecords, pg, pageSize);
            this.ViewBag.Pager = pager;

            //ReactionAgents =ReactionAgents.Skip((pg-1)*pageSize).Take(pageSize).ToList();

            return View(reactionAgents);
        }

        public IActionResult Create()
        {
            ReactionAgent reactionAgent = new ReactionAgent();
            return View(reactionAgent);
        }

        [HttpPost]
        public IActionResult Create(ReactionAgent reactionAgent)
        {
            try
            {
                reactionAgent = _repository.Create(reactionAgent);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            ReactionAgent reactionAgent = _repository.GetReactionAgent(id);
            return View(reactionAgent);
        }

        public IActionResult Edit(int id)
        {
            ReactionAgent reactionAgent = _repository.GetReactionAgent(id);
            return View(reactionAgent);
        }

        [HttpPost]
        public IActionResult Edit(ReactionAgent reactionAgent)
        {
            try
            {
                reactionAgent = _repository.Edit(reactionAgent);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ReactionAgent reactionAgent = _repository.GetReactionAgent(id);
            return View(reactionAgent);
        }

        [HttpPost]
        public IActionResult Delete(ReactionAgent reactionAgent)
        {
            try
            {
                reactionAgent = _repository.Delete(reactionAgent);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }


    }
}

