using System;
using Xamarin.Forms;

//参考url http://dev-suesan.hatenablog.com/entry/2017/03/06/005206

namespace LinqSample001
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //-------------------------------インサートボタン-------------------------------
            var Insert = new Button
            {
                WidthRequest = 60,
                Text = "Insert!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;

            //--------------------------------デリートボタン------------------------------
            var Delete = new Button
            {
                WidthRequest = 60,
                Text = "Delete!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Delete);
            Delete.Clicked += DeleteClicked;

            //--------------------------------セレクトボタン------------------------------
            var Select = new Button
            {
                WidthRequest = 60,
                Text = "Select!",
                TextColor = Color.Red,
            };
            layout.Children.Add(Select);
            Select.Clicked += SelectClicked;

            Content = layout;
        }

        void SelectClicked(object sender, EventArgs e)
        {
            //Userテーブルの行データを取得
            var query = UserModel008.selectUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;
        }

        void InsertClicked(object sender, EventArgs e)
        {
            //Userテーブルに適当なデータを追加する
            UserModel008.insertUser("鈴木");
            UserModel008.insertUser("田中");
            UserModel008.insertUser("斎藤");

        }

        void DeleteClicked(object sender, EventArgs e)
        {
            //Userテーブルに適当なデータを追加する まだです
            //UserModel.deleteUser("鈴木");

        }
    }


}