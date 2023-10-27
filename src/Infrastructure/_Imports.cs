global using System.Security.Claims;

global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;

global using SmartGenealogy.Application.Common.Interfaces;
global using SmartGenealogy.Application.Common.Interfaces.Identity;
global using SmartGenealogy.Application.Common.Models;
global using SmartGenealogy.Domain.Common;
global using SmartGenealogy.Domain.Entities;
global using SmartGenealogy.Domain.Entities.Audit;
global using SmartGenealogy.Domain.Identity;
global using SmartGenealogy.Infrastructure.Middlewares;
global using SmartGenealogy.Infrastructure.Persistence;
global using SmartGenealogy.Infrastructure.Persistence.Extensions;
global using SmartGenealogy.Infrastructure.Services;
global using SmartGenealogy.Infrastructure.Services.Identity;