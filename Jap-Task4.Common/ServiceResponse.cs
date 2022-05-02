﻿namespace Jap_Task4.Services
{
    public class ServiceResponse<Type>
    {
        public Type Data { get; set; }

        public int Count { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}