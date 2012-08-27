using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
//using Utilities;

namespace CZGRQRC
{
    /// <summary>
    /// frmLogin 的摘要说明。
    /// </summary>
    public class frmLogin : System.Windows.Forms.Form
    {
        //public static bool m_Login=false;
        //public static int m_UserID=0;
        //public static string m_UserName = null;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPwd;
        private Label label1;
        private Label label2;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmLogin()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(705, 370);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(70, 21);
            this.btnNo.TabIndex = 5;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.Location = new System.Drawing.Point(629, 370);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(70, 21);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "登录";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(625, 316);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(150, 21);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "user";
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPwd.Location = new System.Drawing.Point(625, 343);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(150, 21);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.Text = "u";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(566, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(566, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(798, 411);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void btnYes_Click(object sender, System.EventArgs e)
        {
            bool b = CZGRQRC.CZGRQRCApp.Default.DBI.CanLogin(this.txtUser.Text,
                this.txtPwd.Text);
            if (b)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure("无效的用户或密码！");
                return;
            }
            //try
            //{
            //    string str=null;
            //    XmlDocument XDoc=new XmlDocument();
            //    XDoc.Load("Server.xml");
            //    XmlNode XNode=XDoc.DocumentElement.SelectSingleNode("./SqlCon");
            //    for(int i=0;i<XNode.ChildNodes.Count;i++)
            //    {
            //        str=str+XNode.ChildNodes[i].Name;
            //        str=str+"=";
            //        str=str+XNode.ChildNodes[i].InnerText.Trim();
            //        str=str+";";
            //    }
            //    SqlConnection sCon=new  SqlConnection(str);
			
				
            //    sCon.Open();
			
            //    string strUser="select * from tbWUser where name='"+txtUser.Text.Trim()+"'";
            //    SqlCommand cmd=new SqlCommand(strUser,sCon);
            //    SqlDataReader dr=cmd.ExecuteReader();
            //    if(!dr.Read())
            //    {
            //        MessageBox.Show("用户不存在！","错误",MessageBoxButtons.OK , MessageBoxIcon.Error);
            //        txtUser.SelectAll();
            //        txtUser.Focus();
            //        dr.Close();
            //        return ;
            //    }
            //    string strPwd=dr["password"].ToString();
            //    int UserID= Convert.ToInt32(dr["ID"]);
            //    dr.Close();
            //    if(strPwd!=txtPwd.Text.Trim())
            //    {
            //        MessageBox.Show("密码无效！","错误",MessageBoxButtons.OK , MessageBoxIcon.Error);
            //        txtPwd.Clear();
            //        txtPwd.Focus();
            //        return ;
            //    }
            //    m_UserName=txtUser.Text.Trim();
            //    m_UserID=UserID;
            //    m_Login=true;
            //    this.Close();
            //}
            //catch(Exception ex)
            //{
            //    // 2007.05.30
            //    //
            //    //MessageBox.Show("连接失败，请测试连接!","连接错误",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //    ExceptionHandler.Handle("连接失败，请测试连接!", ex );
            //    return ;
            //}
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, System.EventArgs e)
        {
            //m_Login=false;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Load(object sender, System.EventArgs e)
        {
            this.txtUser.Focus();
            //string loginFile = "Resources\\logo.jpg";
            //Image img = Image.FromFile(loginFile);
            Image img = CZGRQRC.Properties.Resources.logo;
            //this.BackColor = Color.Black;
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Center;
            this.Width = img.Width + 2;
            this.Height = img.Height + 2;
        }
    }
}
