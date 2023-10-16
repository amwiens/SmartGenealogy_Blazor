﻿namespace SmartGenealogy.Application.Features.Customers.Specifications;

public enum CustomerListView
{
    [Description("All")]
    All,
    [Description("My")]
    My,
    [Description("Created Today")]
    CreatedToday,
    [Description("Created within the last 30 days")]
    Created30Days
}

public class CustomerAdvancedFilter : PaginationFilter
{
    public CustomerListView ListView { get; set; } = CustomerListView.All;

    public UserProfile? CurrentUser { get; set; }
}