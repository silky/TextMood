﻿using Xamarin.Forms;

namespace TextMood
{
	public class App : Application
	{
		public App() => MainPage = new BaseNavigationPage(new TextResultsListPage());
	}
}
