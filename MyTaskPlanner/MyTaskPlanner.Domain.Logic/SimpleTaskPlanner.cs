using MyTaskPlanner.Domain.Models.Models;

namespace MyTaskPlanner.Domain.Logic
{
    public static class SimpleTaskPlanner
    {
        public static WorkItem[] CreatePlan(WorkItem[] workItems)
        {
            var items = workItems.ToList();

            items.Sort(CompareWorkItems);
            return items.ToArray();

        }

        private static int CompareWorkItems(WorkItem firstItem, WorkItem secondItem)
        {
            // Спершу порівнюємо за пріоритетом (спадання).
            int priorityComparison = secondItem.Priority.CompareTo(firstItem.Priority);

            // Якщо пріоритети різні, повертаємо результат порівняння пріоритетів.
            if (priorityComparison != 0)
            {
                return priorityComparison;
            }

            // Якщо пріоритети однакові, порівнюємо за DueDate (зростання).
            int dueDateComparison = firstItem.DueDate.CompareTo(secondItem.DueDate);

            // Якщо дати різні, повертаємо результат порівняння дат.
            if (dueDateComparison != 0)
            {
                return dueDateComparison;
            }

            // Якщо дати однакові, порівнюємо за назвою (алфавітний порядок).
            return firstItem.Title.CompareTo(secondItem.Title);
        }
    }
}