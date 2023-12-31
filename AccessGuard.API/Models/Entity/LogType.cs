﻿namespace AccessGuard_API.Models.Entity
{
    public class LogType
    {
        public Guid Id { get; set; } = new Guid();
        public string Description { get; set; } = null!;

        public ICollection<Logs> Logs { get; set; } = null!;
    }
}