﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
	public class App : Application
	{
		static TodoItemDatabase database;

		public App()
		{
			Resources = new ResourceDictionary();
			Resources.Add("primaryPink", Color.FromHex("E91E63"));
			Resources.Add("primaryPinkDark", Color.FromHex("C2185B"));

            NavigationPage newPage = new NavigationPage(new TodoListPage());

            
           // newPage.BarBackgroundColor = (Color)App.Current.Resources["primaryPinkDark"];
            var nav = newPage;
			nav.BarBackgroundColor = (Color)App.Current.Resources["primaryPink"];

			nav.BarTextColor = Color.White;

			MainPage = nav;
            MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, (Color)App.Current.Resources["primaryPinkDark"]);
		}

		public static TodoItemDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
				}
				return database;
			}
		}

		public int ResumeAtTodoId { get; set; }

		protected override void OnStart()
		{
			//Debug.WriteLine("OnStart");

			//// always re-set when the app starts
			//// users expect this (usually)
			////			Properties ["ResumeAtTodoId"] = "";
			//if (Properties.ContainsKey("ResumeAtTodoId"))
			//{
			//	var rati = Properties["ResumeAtTodoId"].ToString();
			//	Debug.WriteLine("   rati=" + rati);
			//	if (!String.IsNullOrEmpty(rati))
			//	{
			//		Debug.WriteLine("   rati=" + rati);
			//		ResumeAtTodoId = int.Parse(rati);

			//		if (ResumeAtTodoId >= 0)
			//		{
			//			var todoPage = new TodoItemPage();
			//			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
			//			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
			//		}
			//	}
			//}
		}

		protected override void OnSleep()
		{
			//Debug.WriteLine("OnSleep saving ResumeAtTodoId = " + ResumeAtTodoId);
			//// the app should keep updating this value, to
			//// keep the "state" in case of a sleep/resume
			//Properties["ResumeAtTodoId"] = ResumeAtTodoId;
		}

		protected override void OnResume()
		{
			//Debug.WriteLine("OnResume");
			//if (Properties.ContainsKey("ResumeAtTodoId"))
			//{
			//	var rati = Properties["ResumeAtTodoId"].ToString();
			//	Debug.WriteLine("   rati=" + rati);
			//	if (!String.IsNullOrEmpty(rati))
			//	{
			//		Debug.WriteLine("   rati=" + rati);
			//		ResumeAtTodoId = int.Parse(rati);

			//		if (ResumeAtTodoId >= 0)
			//		{
			//			var todoPage = new TodoItemPage();
			//			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
			//			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
			//		}
			//	}
			//}
		}
	}
}

