﻿using TanuloKartyak.Views;

namespace TanuloKartyak;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
	}
}