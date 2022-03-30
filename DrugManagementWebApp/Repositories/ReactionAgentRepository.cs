using DrugManagementWebApp.Data;
using DrugManagementWebApp.Interfaces;
using DrugManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugManagementWebApp.Repositories
{
    public class ReactionAgentRepository : IReactionAgent
    {
        private readonly ApplicationContext _context;
        public ReactionAgentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public PaginatedList<ReactionAgent> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<ReactionAgent> reactionAgents;

            if (SearchText != "" && SearchText != null)
            {
                reactionAgents = _context.ReactionAgents.Where(n => n.ReactAgentShortName.Contains(SearchText) || n.ReactAgentLongName.Contains(SearchText) || n.ReactAgentDescription.Contains(SearchText)).ToList();
            }
            else
                reactionAgents = _context.ReactionAgents.ToList();


            PaginatedList<ReactionAgent> retReactionAgents = new PaginatedList<ReactionAgent>(reactionAgents, pageIndex, pageSize);

            return retReactionAgents;
        }
        public ReactionAgent GetReactionAgent(int id)
        {
            ReactionAgent reactionAgent = _context.ReactionAgents.Where(d => d.ReactionAgentId == id).FirstOrDefault();
            return reactionAgent;
        }

        public ReactionAgent Create(ReactionAgent reactionAgent)
        {
            _context.ReactionAgents.Add(reactionAgent);
            _context.SaveChanges();
            return reactionAgent;
        }

        public ReactionAgent Edit(ReactionAgent reactionAgent)
        {
            _context.ReactionAgents.Attach(reactionAgent);
            _context.Entry(reactionAgent).State = EntityState.Modified;
            _context.SaveChanges();
            return reactionAgent;
        }

        public ReactionAgent Delete(ReactionAgent reactionAgent)
        {
            _context.ReactionAgents.Attach(reactionAgent);
            _context.Entry(reactionAgent).State = EntityState.Deleted;
            _context.SaveChanges();
            return reactionAgent;
        }
    }
}

