﻿namespace SkateShop.Domain.Entities
{
    public class TopBarMessage : Entity
    {
        public string Message { get; set; } = string.Empty;

        public TopBarMessage()
        {
        }

        public TopBarMessage(string message)
        {
            Message = message;
        }
    }
}
