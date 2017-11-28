using Xamarin.Forms;

namespace LinqSample001
{
    public partial class LinqSamplePage008 : ContentPage
    {
        public LinqSamplePage008()
        {
            InitializeComponent();
        }

        private void Button_Insert(object sender, EventArgs e)//インサートボタン押されたら
        {
            int i = int.Parse(insert.Text);//インサートするのかどうか

            if (i == 1)//1が入力されたら↓
            {
                //Userテーブルに適当なデータを追加する
                UserModel008.insertUser(1, "鈴木");
                UserModel008.insertUser("田中");
                UserModel008.insertUser("斎藤");
            }
        }

        private void Button_Select(object sender, EventArgs e)//セレクトボタン押されたら
        {
            int count = 0;
            count = UserModel008.countUser();

            UserModel008.selectUser();

            for (int i = 1; i <= count; i++)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Id.ToString() });
                layout.Children.Add(new Label { Text = user.Name });
            }
        }
    }
}
        