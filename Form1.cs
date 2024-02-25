using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lobby
{
    public partial class Form1 : Form
    {
        private Image backgroundImage;
        private List<User> loggedInUsers;
        
        public Form1()
        {
            InitializeComponent();
            loggedInUsers = new List<User>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Đặt hình ảnh làm nền
            SetBackgroundImage(Properties.Resources.class1);
        }

        public void SetBackgroundImage(Image image)
        {
            // Đặt hình ảnh làm nền cho form
            backgroundImage = image;
            Refresh();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            // Vẽ hình ảnh nền
            if (backgroundImage != null)
            {
                e.Graphics.DrawImage(backgroundImage, 0, 0, Width, Height);
            }
        }

        public void AddLoggedInUser(string username)
        {
            // Thêm người dùng đã đăng nhập vào danh sách
            loggedInUsers.Add(new User(username));
            UpdateUserList();
        }

        public void RemoveLoggedInUser(string username)
        {
            // Xóa người dùng đã đăng nhập khỏi danh sách
            loggedInUsers.RemoveAll(user => user.Username == username);
            UpdateUserList();
        }

        private void UpdateUserList()
        {
            // Xóa các hình ảnh đại diện hiện có trong FlowLayoutPanel
            flowLayoutPanel.Controls.Clear();

            // Thêm hình ảnh đại diện và tên người dùng cho mỗi người dùng đã đăng nhập
            foreach (User user in loggedInUsers)
            {
                Image userImage = GetUserImage(user.Username); // Lấy hình ảnh đại diện cho người dùng

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = userImage;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = 50;
                pictureBox.Height = 50;
                pictureBox.Margin = new Padding(5);

                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.Text = user.Username;
                label.TextAlign = ContentAlignment.MiddleCenter;

                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.FlowDirection = FlowDirection.TopDown;
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(label);

                flowLayoutPanel.Controls.Add(panel);
            }
        }

        private Image GetUserImage(string username)
        {
            // TODO: Trả về hình ảnh đại diện tương ứng với người dùng
            // Việc lấy hình ảnh đại diện có thể thực hiện thông qua API hoặc hệ thống lưu trữ hình ảnh của bạn
            // Trong ví dụ này, chúng ta giả định sẽ trả về một hình ảnh mặc định
            return Properties.Resources.images;
        }
    }

    public class User
    {
        public string Username { get; }

        public User(string username)
        {
            Username = username;
        }
    }
}
