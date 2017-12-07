using System;
using Xamarin.Forms;

namespace LinqSample001
{
    public partial class MainPage : ContentPage
    {
        private Entry InsertEntry; //テキストボックスの値を保持する

        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //-----------------------------インサートするテキストボックス-------------------
            InsertEntry = new Entry
            {
                WidthRequest = 60
            };
            layout.Children.Add(InsertEntry);


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

            //-----------------------------selectした結果がnullじゃなかったら（=表の中身が入っていたらselectメソッドを実行）----------------------
            if (UserModel008.selectUser() != null)
            {
                var query = UserModel008.selectUser();

                foreach (var user in query)
                {
                    //Userテーブルの名前列をLabelに書き出す
                    layout.Children.Add(new Label { Text = user.Id.ToString() });
                    layout.Children.Add(new Label { Text = user.Name });
                }
            }
            Content = layout;
        }
    }   
        public void SelectClicked(object sender, EventArgs e)
        {
            //Userテーブルの行データを取得
            var query = UserModel008.selectUser();
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //UserテーブルのId列とName列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Id.ToString() });
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;
        }

        /************************************インサートボタンが押されたら（長い）*****************************************/
        public void InsertClicked(object sender, EventArgs e)
        {
            //Userテーブルに適当なデータを追加する
            UserModel008.insertUser(1,InsertEntry.Text);

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //ボタン再配置（見かけ上消えないようにする）
            //-----------------------------インサートするテキストボックス-------------------
            InsertEntry = new Entry
            {
                WidthRequest = 60
            };
            layout.Children.Add(InsertEntry);


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

           　/************セレクトかける*********************/
             var query = UserModel008.selectUser();

             foreach (var user in query)
             {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Id.ToString() });
                layout.Children.Add(new Label { Text = user.Name });
             }
            
            Content = layout;
        }
        
        /********************************デリートボタンが押されたら************************************************************************/
        public void DeleteClicked(object sender, EventArgs e)
        {
            UserModel008.deleteUser(1);

        }
 }