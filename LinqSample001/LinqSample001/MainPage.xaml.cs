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
                Text = "INSERT",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Insert);
            Insert.Clicked += InsertClicked;

            //--------------------------------デリートボタン------------------------------
            var Delete = new Button
            {
                WidthRequest = 60,
                Text = "DELETE",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Delete);
            Delete.Clicked += DeleteClicked;

            //--------------------------------セレクトボタン------------------------------
            var Select = new Button
            {
                WidthRequest = 60,
                Text = "SELECT",
                TextColor = Color.Blue,
            };
            layout.Children.Add(Select);
            Select.Clicked += SelectClicked;

            Content = layout;
        }

        public void SelectClicked(object sender, EventArgs e)
        {
            //Userテーブルの行データを取得
            var query = UserModel008.selectUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //UserテーブルのId列とName列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
                layout.Children.Add(new Label { Text = user.Id });
            }
            Content = layout;
        }

        public void InsertClicked(object sender, EventArgs e)
        {
            //Userテーブルに適当なデータを追加する
            UserModel008.insertUser(1,"鈴木");
            UserModel008.insertUser("田中");
            UserModel008.insertUser("斎藤");

        }

        public void DeleteClicked(object sender, EventArgs e)
        {
            //UserModel008.deleteUser("鈴木");

        }
    }


}