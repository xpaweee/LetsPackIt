using System;
using LetsPackIt.Shared.Abstractions.Exceptions;

namespace LetsPackIt.Application.Exceptions
{
    public class PackingListAlreadyExistsException : LetsPackItException
    {
        public string Name { get; }

        public PackingListAlreadyExistsException(string name) : base($"Packing list with name {name} already exists")
        {
            Name = name;
        }
    }
}