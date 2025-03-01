﻿using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICustomerRepository : IAsyncRepository<Customer, int>, IRepository<Customer, int>
{

}
