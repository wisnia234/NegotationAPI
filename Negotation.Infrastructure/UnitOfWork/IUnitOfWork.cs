﻿namespace Negotation.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> func);
}
