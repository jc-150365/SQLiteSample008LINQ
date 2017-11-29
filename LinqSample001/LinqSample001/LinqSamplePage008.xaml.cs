using Xamarin.Forms;

namespace LinqSample001
{
    public partial class LinqSamplePage008 : ContentPage
    {
        public LinqSamplePage008()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            var insertButton = new Button
            {
                WidthRequest = 60,
                TextColor = Color.Blue,
                Text = "insert"
            };
            layout.Children.Add(insertButton);
            insertButton.Clicked += insertClicked;

            var selectButton = new Button
            {
                WidthRequest = 60,
                TextColor = Color.Blue,
                Text = "select"
            };
            layout.Children.Add(selectButton);
            insertButton.Clicked += selectClicked;

            void insertClicked(object sender, EventArgs e)
            {
                //Userテーブルに適当なデータを追加する
                UserModel008.insertUser("1,鈴木");
                UserModel008.insertUser("田中");
                UserModel008.insertUser("斎藤");

            }

            void selectClicked(object sender, EventArgs e)
            {
                //Userテーブルの行データを取得
                var query = UserModel008.selectUser();

                foreach (var user in query)
                {

                    //Userテーブルの名前列をLabelに書き出す
                    layout.Children.Add(new Label { Text = user.Id.ToString() });
                    layout.Children.Add(new Label { Text = user.Name });
                }
                //Content = layout;

            }
            Content = layout;

        }
    }
}
