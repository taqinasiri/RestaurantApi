global using AutoMapper;
global using FluentValidation;
global using MediatR;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Restaurant.Application.Constants;
global using Restaurant.Application.Contracts.Infrastructure;
global using Restaurant.Application.Contracts.Persistence;
global using Restaurant.Application.Exceptions;
global using Restaurant.Application.Extensions;
global using Restaurant.Application.Helpers;
global using Restaurant.Application.Models;
global using Restaurant.Domain.Entities;
global using Restaurant.Domain.Entities.Identity;
global using System.Security.Claims;

global using Entities = Restaurant.Domain.Entities;