using Xamarin.Forms;

namespace LinqSample001
{
    public partial class LinqSamplePage008 : ContentPage
    {
        public LinqSamplePage008()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            var entry = new Entry
            {
                WidthRequest = 60,
                TextColor = Color.White,
                Text = "Add"
            };


            if(UserModel008.selectFlug() != true) //起動する度にインサートかかるのを防ぐ
            {
                //Userテーブルに適当なデータを追加する
                UserModel008.insertUser(1, "鈴木");
                UserModel008.insertUser("田中");
                UserModel008.insertUser("斎藤");
            }


            var buttonAdd = new Button
            {
                WidthRequest = 60,
                TextColor = Color.White,
                Text = "Add"
            };

            layout.Children.Add(buttonAdd);

            //Userテーブルの行データを取得
            var query = UserModel008.selectUser();

            foreach (var user in query)
            {

                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Id.ToString() });
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;
        }
    }
}
