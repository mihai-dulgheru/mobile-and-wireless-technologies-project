﻿using Project.Views;

namespace Project;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(SearchProductPage), typeof(SearchProductPage));
    }
}
