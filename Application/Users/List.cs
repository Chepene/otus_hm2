using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistnce;

namespace Application.Users
{
    public class List
    {
        public class Query : IRequest<List<User>>{}

        public class Handler : IRequestHandler<Query, List<User>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<User>> Handle(Query request, CancellationToken cancellationToken)
            {
               return await _context.Users.ToListAsync();
            }
        }



    }
}