using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect_medii.Data;

namespace proiect_medii.Models
{
    public class ZborTerminalePageModel: PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(proiect_mediiContext context, Zbor zbor)
        {
            var allTerminale = context.Terminal;
            var zborTerminale = new HashSet<int>(
            zbor.ZborTerminale.Select(c => c.TerminalID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allTerminale)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.Nume_terminal,
                    Assigned = zborTerminale.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(proiect_mediiContext context,
        string[] selectedTerminale, Zbor zborToUpdate)
        {
            if (selectedTerminale == null)
            {
                zborToUpdate.ZborTerminale = new List<ZborTerminal>();
                return;
            }
            var selectedTerminaleHS = new HashSet<string>(selectedTerminale);
            var zborTerminale = new HashSet<int>
            (zborToUpdate.ZborTerminale.Select(c => c.Terminal.ID));
            foreach (var cat in context.Terminal)
            {
                if (selectedTerminaleHS.Contains(cat.ID.ToString()))
                {
                    if (!zborTerminale.Contains(cat.ID))
                    {
                        zborToUpdate.ZborTerminale.Add(
                        new ZborTerminal
                        {
                            ZborID = zborToUpdate.ID,
                            TerminalID = cat.ID
                        });
                    }
                }
                else
                {
                    if (zborTerminale.Contains(cat.ID))
                    {
                        ZborTerminal courseToRemove
                        = zborToUpdate
                        .ZborTerminale
                        .SingleOrDefault(i => i.TerminalID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
