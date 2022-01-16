using System;
using LetsPackIt.Shared.Abstractions.Exceptions;

namespace LetsPackIt.Application.Exceptions
{
    public class PackingListNotFoundException : LetsPackItException
    {
        public Guid Id { get; }

        public PackingListNotFoundException(Guid id) : base($"Packing list with ID '{id}' was not found.")
            => Id = id;
    }
}