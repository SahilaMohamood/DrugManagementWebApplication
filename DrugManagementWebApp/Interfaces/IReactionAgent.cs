using DrugManagementWebApp.Models;

namespace DrugManagementWebApp.Interfaces
{
    public interface IReactionAgent
    {

        PaginatedList<ReactionAgent> GetItems(string SearchText = "", int pageIndex = 1, int pageSize = 5);  //read all
        ReactionAgent GetReactionAgent(int id);
        ReactionAgent Create(ReactionAgent reactionAgent);
        ReactionAgent Edit(ReactionAgent reactionAgent);
        ReactionAgent Delete(ReactionAgent reactionAgent);
    }
}
