﻿namespace Projekt.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryGroup>? CategoryGroups { get; set; }
    }
}
