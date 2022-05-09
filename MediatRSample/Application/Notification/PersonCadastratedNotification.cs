﻿using MediatR;

namespace MediatRSample.Application.Notification
{
    public class PersonCadastratedNotification : INotification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }
}