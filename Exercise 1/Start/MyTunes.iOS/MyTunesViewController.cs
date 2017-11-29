using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace MyTunes
{
	public class MyTunesViewController : UITableViewController
	{
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

		    //TableView.Source = new ViewControllerSource<string>(TableView) {
		    //    DataSource = new string[] { "One", "Two", "Three" },
		    //};

		    // Load the data
		    var data = await SongLoader.Load();

		    // Register the TableView's data source
		    TableView.Source = new ViewControllerSource<Song>(TableView)
		    {
		        DataSource = data.ToList(),
		        TextProc = s => s.Name,
		        DetailTextProc = s => s.Artist + " - " + s.Album,
		    };
        }
	}

}

