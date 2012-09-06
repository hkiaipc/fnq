using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CZGRQRC
{
    public partial class frmCZGRMap : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public enum ValueType
        {
            T1,
            T2,
            P1,
            P2,
        }

        private Hashtable _nameHashtable = new Hashtable();
        private Hashtable _value1Hashtable = new Hashtable();
        private Hashtable _value2Hashtable = new Hashtable();

        /// <summary>
        /// 
        /// </summary>
        public frmCZGRMap()
        {
            InitializeComponent();
            //_value1Hashtable.Add(1, lab1Value1);
            Init();
            InitNameValues();
            FillStationName();
            _t = new T(Config.Default.AutoRefreshGRDataLastTimeSpan);

        }

        /// <summary>
        /// 
        /// </summary>
        private void InitNameValues()
        {
            foreach (DictionaryEntry de in this._nameHashtable)
            {
                Label lbl = (Label)de.Value;
                lbl.Text = string.Empty;
            }
            foreach (DictionaryEntry de in this._value1Hashtable)
            {
                Label lbl = (Label)de.Value;
                lbl.Text = string.Empty;
            }
            foreach (DictionaryEntry de in this._value2Hashtable)
            {
                Label lbl = (Label)de.Value;
                lbl.Text = string.Empty;
            }
        }

        #region Init
        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            _nameHashtable.Add(1, lab1);
            _nameHashtable.Add(2, lab2);
            _nameHashtable.Add(3, lab3);
            _nameHashtable.Add(4, lab4);
            _nameHashtable.Add(5, lab5);
            _nameHashtable.Add(6, lab6);
            _nameHashtable.Add(7, lab7);
            _nameHashtable.Add(8, lab8);
            _nameHashtable.Add(9, lab9);
            _nameHashtable.Add(10, lab10);
            _nameHashtable.Add(11, lab11);
            _nameHashtable.Add(12, lab12);
            _nameHashtable.Add(13, lab13);
            _nameHashtable.Add(14, lab14);
            _nameHashtable.Add(15, lab15);
            _nameHashtable.Add(16, lab16);
            _nameHashtable.Add(17, lab17);
            _nameHashtable.Add(18, lab18);
            _nameHashtable.Add(19, lab19);
            _nameHashtable.Add(20, lab20);
            _nameHashtable.Add(21, lab21);
            _nameHashtable.Add(22, lab22);
            _nameHashtable.Add(23, lab23);
            _nameHashtable.Add(24, lab24);
            _nameHashtable.Add(25, lab25);
            _nameHashtable.Add(26, lab26);
            _nameHashtable.Add(27, lab27);
            _nameHashtable.Add(28, lab28);
            _nameHashtable.Add(29, lab29);
            _nameHashtable.Add(30, lab30);
            _nameHashtable.Add(31, lab31);
            _nameHashtable.Add(32, lab32);
            _nameHashtable.Add(33, lab33);
            _nameHashtable.Add(34, lab34);
            _nameHashtable.Add(35, lab35);
            _nameHashtable.Add(36, lab36);
            _nameHashtable.Add(37, lab37);
            _nameHashtable.Add(38, lab38);
            _nameHashtable.Add(39, lab39);
            _nameHashtable.Add(40, lab40);
            _nameHashtable.Add(41, lab41);
            _nameHashtable.Add(42, lab42);
            _nameHashtable.Add(43, lab43);
            _nameHashtable.Add(44, lab44);
            _nameHashtable.Add(45, lab45);
            _nameHashtable.Add(46, lab46);
            _nameHashtable.Add(47, lab47);
            _nameHashtable.Add(48, lab48);
            _nameHashtable.Add(49, lab49);
            _nameHashtable.Add(50, lab50);
            _nameHashtable.Add(51, lab51);
            _nameHashtable.Add(52, lab52);
            _nameHashtable.Add(53, lab53);
            _nameHashtable.Add(54, lab54);
            _nameHashtable.Add(55, lab55);
            _nameHashtable.Add(56, lab56);
            _nameHashtable.Add(57, lab57);
            _nameHashtable.Add(58, lab58);
            _nameHashtable.Add(59, lab59);
            _nameHashtable.Add(60, lab60);
            _nameHashtable.Add(61, lab61);
            _nameHashtable.Add(62, lab62);
            _nameHashtable.Add(63, lab63);
            _nameHashtable.Add(64, lab64);
            _nameHashtable.Add(65, lab65);
            _nameHashtable.Add(66, lab66);
            _nameHashtable.Add(67, lab67);
            _nameHashtable.Add(68, lab68);
            _nameHashtable.Add(69, lab69);
            _nameHashtable.Add(70, lab70);
            _nameHashtable.Add(71, lab71);
            _nameHashtable.Add(72, lab72);
            _nameHashtable.Add(73, lab73);
            _nameHashtable.Add(74, lab74);
            _nameHashtable.Add(75, lab75);
            _nameHashtable.Add(76, lab76);
            _nameHashtable.Add(77, lab77);
            _nameHashtable.Add(78, lab78);
            _nameHashtable.Add(79, lab79);
            _nameHashtable.Add(80, lab80);
            _nameHashtable.Add(81, lab81);
            _nameHashtable.Add(82, lab82);
            _nameHashtable.Add(83, lab83);
            _nameHashtable.Add(84, lab84);
            _nameHashtable.Add(85, lab85);
            _nameHashtable.Add(86, lab86);
            _nameHashtable.Add(87, lab87);
            _nameHashtable.Add(88, lab88);
            _nameHashtable.Add(89, lab89);
            _nameHashtable.Add(90, lab90);
            _nameHashtable.Add(91, lab91);
            _nameHashtable.Add(92, lab92);
            _nameHashtable.Add(93, lab93);
            _nameHashtable.Add(94, lab94);
            _nameHashtable.Add(95, lab95);
            _nameHashtable.Add(96, lab96);
            _nameHashtable.Add(97, lab97);
            _nameHashtable.Add(98, lab98);
            _nameHashtable.Add(99, lab99);
            _nameHashtable.Add(100, lab100);
            _nameHashtable.Add(101, lab101);
            _nameHashtable.Add(102, lab102);
            _nameHashtable.Add(103, lab103);
            _nameHashtable.Add(104, lab104);
            _nameHashtable.Add(105, lab105);
            _nameHashtable.Add(106, lab106);
            _nameHashtable.Add(107, lab107);
            _nameHashtable.Add(108, lab108);
            _nameHashtable.Add(109, lab109);
            _nameHashtable.Add(110, lab110);
            _nameHashtable.Add(111, lab111);
            _nameHashtable.Add(112, lab112);
            _nameHashtable.Add(113, lab113);
            _nameHashtable.Add(114, lab114);
            _nameHashtable.Add(115, lab115);
            _nameHashtable.Add(116, lab116);
            _nameHashtable.Add(117, lab117);
            _nameHashtable.Add(118, lab118);
            _nameHashtable.Add(119, lab119);
            _nameHashtable.Add(120, lab120);
            _nameHashtable.Add(121, lab121);
            _nameHashtable.Add(122, lab122);
            _nameHashtable.Add(123, lab123);
            _nameHashtable.Add(124, lab124);
            _nameHashtable.Add(125, lab125);
            _nameHashtable.Add(126, lab126);
            _nameHashtable.Add(127, lab127);
            _nameHashtable.Add(128, lab128);
            _nameHashtable.Add(129, lab129);
            _nameHashtable.Add(130, lab130);
            _nameHashtable.Add(131, lab131);
            _nameHashtable.Add(132, lab132);
            _nameHashtable.Add(133, lab133);
            _nameHashtable.Add(134, lab134);
            _nameHashtable.Add(135, lab135);
            _nameHashtable.Add(136, lab136);
            _nameHashtable.Add(137, lab137);
            _nameHashtable.Add(138, lab138);
            _nameHashtable.Add(139, lab139);
            _nameHashtable.Add(140, lab140);
            _nameHashtable.Add(141, lab141);

            _value1Hashtable.Add(1, lab1Value1);
            _value1Hashtable.Add(2, lab2Value1);
            _value1Hashtable.Add(3, lab3Value1);
            _value1Hashtable.Add(4, lab4Value1);
            _value1Hashtable.Add(5, lab5Value1);
            _value1Hashtable.Add(6, lab6Value1);
            _value1Hashtable.Add(7, lab7Value1);
            _value1Hashtable.Add(8, lab8Value1);
            _value1Hashtable.Add(9, lab9Value1);
            _value1Hashtable.Add(10, lab10Value1);
            _value1Hashtable.Add(11, lab11Value1);
            _value1Hashtable.Add(12, lab12Value1);
            _value1Hashtable.Add(13, lab13Value1);
            _value1Hashtable.Add(14, lab14Value1);
            _value1Hashtable.Add(15, lab15Value1);
            _value1Hashtable.Add(16, lab16Value1);
            _value1Hashtable.Add(17, lab17Value1);
            _value1Hashtable.Add(18, lab18Value1);
            _value1Hashtable.Add(19, lab19Value1);
            _value1Hashtable.Add(20, lab20Value1);
            _value1Hashtable.Add(21, lab21Value1);
            _value1Hashtable.Add(22, lab22Value1);
            _value1Hashtable.Add(23, lab23Value1);
            _value1Hashtable.Add(24, lab24Value1);
            _value1Hashtable.Add(25, lab25Value1);
            _value1Hashtable.Add(26, lab26Value1);
            _value1Hashtable.Add(27, lab27Value1);
            _value1Hashtable.Add(28, lab28Value1);
            _value1Hashtable.Add(29, lab29Value1);
            _value1Hashtable.Add(30, lab30Value1);
            _value1Hashtable.Add(31, lab31Value1);
            _value1Hashtable.Add(32, lab32Value1);
            _value1Hashtable.Add(33, lab33Value1);
            _value1Hashtable.Add(34, lab34Value1);
            _value1Hashtable.Add(35, lab35Value1);
            _value1Hashtable.Add(36, lab36Value1);
            _value1Hashtable.Add(37, lab37Value1);
            _value1Hashtable.Add(38, lab38Value1);
            _value1Hashtable.Add(39, lab39Value1);
            _value1Hashtable.Add(40, lab40Value1);
            _value1Hashtable.Add(41, lab41Value1);
            _value1Hashtable.Add(42, lab42Value1);
            _value1Hashtable.Add(43, lab43Value1);
            _value1Hashtable.Add(44, lab44Value1);
            _value1Hashtable.Add(45, lab45Value1);
            _value1Hashtable.Add(46, lab46Value1);
            _value1Hashtable.Add(47, lab47Value1);
            _value1Hashtable.Add(48, lab48Value1);
            _value1Hashtable.Add(49, lab49Value1);
            _value1Hashtable.Add(50, lab50Value1);
            _value1Hashtable.Add(51, lab51Value1);
            _value1Hashtable.Add(52, lab52Value1);
            _value1Hashtable.Add(53, lab53Value1);
            _value1Hashtable.Add(54, lab54Value1);
            _value1Hashtable.Add(55, lab55Value1);
            _value1Hashtable.Add(56, lab56Value1);
            _value1Hashtable.Add(57, lab57Value1);
            _value1Hashtable.Add(58, lab58Value1);
            _value1Hashtable.Add(59, lab59Value1);
            _value1Hashtable.Add(60, lab60Value1);
            _value1Hashtable.Add(61, lab61Value1);
            _value1Hashtable.Add(62, lab62Value1);
            _value1Hashtable.Add(63, lab63Value1);
            _value1Hashtable.Add(64, lab64Value1);
            _value1Hashtable.Add(65, lab65Value1);
            _value1Hashtable.Add(66, lab66Value1);
            _value1Hashtable.Add(67, lab67Value1);
            _value1Hashtable.Add(68, lab68Value1);
            _value1Hashtable.Add(69, lab69Value1);
            _value1Hashtable.Add(70, lab70Value1);
            _value1Hashtable.Add(71, lab71Value1);
            _value1Hashtable.Add(72, lab72Value1);
            _value1Hashtable.Add(73, lab73Value1);
            _value1Hashtable.Add(74, lab74Value1);
            _value1Hashtable.Add(75, lab75Value1);
            _value1Hashtable.Add(76, lab76Value1);
            _value1Hashtable.Add(77, lab77Value1);
            _value1Hashtable.Add(78, lab78Value1);
            _value1Hashtable.Add(79, lab79Value1);
            _value1Hashtable.Add(80, lab80Value1);
            _value1Hashtable.Add(81, lab81Value1);
            _value1Hashtable.Add(82, lab82Value1);
            _value1Hashtable.Add(83, lab83Value1);
            _value1Hashtable.Add(84, lab84Value1);
            _value1Hashtable.Add(85, lab85Value1);
            _value1Hashtable.Add(86, lab86Value1);
            _value1Hashtable.Add(87, lab87Value1);
            _value1Hashtable.Add(88, lab88Value1);
            _value1Hashtable.Add(89, lab89Value1);
            _value1Hashtable.Add(90, lab90Value1);
            _value1Hashtable.Add(91, lab91Value1);
            _value1Hashtable.Add(92, lab92Value1);
            _value1Hashtable.Add(93, lab93Value1);
            _value1Hashtable.Add(94, lab94Value1);
            _value1Hashtable.Add(95, lab95Value1);
            _value1Hashtable.Add(96, lab96Value1);
            _value1Hashtable.Add(97, lab97Value1);
            _value1Hashtable.Add(98, lab98Value1);
            _value1Hashtable.Add(99, lab99Value1);
            _value1Hashtable.Add(100, lab100Value1);
            _value1Hashtable.Add(101, lab101Value1);
            _value1Hashtable.Add(102, lab102Value1);
            _value1Hashtable.Add(103, lab103Value1);
            _value1Hashtable.Add(104, lab104Value1);
            _value1Hashtable.Add(105, lab105Value1);
            _value1Hashtable.Add(106, lab106Value1);
            _value1Hashtable.Add(107, lab107Value1);
            _value1Hashtable.Add(108, lab108Value1);
            _value1Hashtable.Add(109, lab109Value1);
            _value1Hashtable.Add(110, lab110Value1);
            _value1Hashtable.Add(111, lab111Value1);
            _value1Hashtable.Add(112, lab112Value1);
            _value1Hashtable.Add(113, lab113Value1);
            _value1Hashtable.Add(114, lab114Value1);
            _value1Hashtable.Add(115, lab115Value1);
            _value1Hashtable.Add(116, lab116Value1);
            _value1Hashtable.Add(117, lab117Value1);
            _value1Hashtable.Add(118, lab118Value1);
            _value1Hashtable.Add(119, lab119Value1);
            _value1Hashtable.Add(120, lab120Value1);
            _value1Hashtable.Add(121, lab121Value1);
            _value1Hashtable.Add(122, lab122Value1);
            _value1Hashtable.Add(123, lab123Value1);
            _value1Hashtable.Add(124, lab124Value1);
            _value1Hashtable.Add(125, lab125Value1);
            _value1Hashtable.Add(126, lab126Value1);
            _value1Hashtable.Add(127, lab127Value1);
            _value1Hashtable.Add(128, lab128Value1);
            _value1Hashtable.Add(129, lab129Value1);
            _value1Hashtable.Add(130, lab130Value1);
            _value1Hashtable.Add(131, lab131Value1);
            _value1Hashtable.Add(132, lab132Value1);
            _value1Hashtable.Add(133, lab133Value1);
            _value1Hashtable.Add(134, lab134Value1);
            _value1Hashtable.Add(135, lab135Value1);
            _value1Hashtable.Add(136, lab136Value1);
            _value1Hashtable.Add(137, lab137Value1);
            _value1Hashtable.Add(138, lab138Value1);
            _value1Hashtable.Add(139, lab139Value1);
            _value1Hashtable.Add(140, lab140Value1);
            _value1Hashtable.Add(141, lab141Value1);
            

            _value2Hashtable.Add(1, lab1Value2);
            _value2Hashtable.Add(2, lab2Value2);
            _value2Hashtable.Add(3, lab3Value2);
            _value2Hashtable.Add(4, lab4Value2);
            _value2Hashtable.Add(5, lab5Value2);
            _value2Hashtable.Add(6, lab6Value2);
            _value2Hashtable.Add(7, lab7Value2);
            _value2Hashtable.Add(8, lab8Value2);
            _value2Hashtable.Add(9, lab9Value2);
            _value2Hashtable.Add(10, lab10Value2);
            _value2Hashtable.Add(11, lab11Value2);
            _value2Hashtable.Add(12, lab12Value2);
            _value2Hashtable.Add(13, lab13Value2);
            _value2Hashtable.Add(14, lab14Value2);
            _value2Hashtable.Add(15, lab15Value2);
            _value2Hashtable.Add(16, lab16Value2);
            _value2Hashtable.Add(17, lab17Value2);
            _value2Hashtable.Add(18, lab18Value2);
            _value2Hashtable.Add(19, lab19Value2);
            _value2Hashtable.Add(20, lab20Value2);
            _value2Hashtable.Add(21, lab21Value2);
            _value2Hashtable.Add(22, lab22Value2);
            _value2Hashtable.Add(23, lab23Value2);
            _value2Hashtable.Add(24, lab24Value2);
            _value2Hashtable.Add(25, lab25Value2);
            _value2Hashtable.Add(26, lab26Value2);
            _value2Hashtable.Add(27, lab27Value2);
            _value2Hashtable.Add(28, lab28Value2);
            _value2Hashtable.Add(29, lab29Value2);
            _value2Hashtable.Add(30, lab30Value2);
            _value2Hashtable.Add(31, lab31Value2);
            _value2Hashtable.Add(32, lab32Value2);
            _value2Hashtable.Add(33, lab33Value2);
            _value2Hashtable.Add(34, lab34Value2);
            _value2Hashtable.Add(35, lab35Value2);
            _value2Hashtable.Add(36, lab36Value2);
            _value2Hashtable.Add(37, lab37Value2);
            _value2Hashtable.Add(38, lab38Value2);
            _value2Hashtable.Add(39, lab39Value2);
            _value2Hashtable.Add(40, lab40Value2);
            _value2Hashtable.Add(41, lab41Value2);
            _value2Hashtable.Add(42, lab42Value2);
            _value2Hashtable.Add(43, lab43Value2);
            _value2Hashtable.Add(44, lab44Value2);
            _value2Hashtable.Add(45, lab45Value2);
            _value2Hashtable.Add(46, lab46Value2);
            _value2Hashtable.Add(47, lab47Value2);
            _value2Hashtable.Add(48, lab48Value2);
            _value2Hashtable.Add(49, lab49Value2);
            _value2Hashtable.Add(50, lab50Value2);
            _value2Hashtable.Add(51, lab51Value2);
            _value2Hashtable.Add(52, lab52Value2);
            _value2Hashtable.Add(53, lab53Value2);
            _value2Hashtable.Add(54, lab54Value2);
            _value2Hashtable.Add(55, lab55Value2);
            _value2Hashtable.Add(56, lab56Value2);
            _value2Hashtable.Add(57, lab57Value2);
            _value2Hashtable.Add(58, lab58Value2);
            _value2Hashtable.Add(59, lab59Value2);
            _value2Hashtable.Add(60, lab60Value2);
            _value2Hashtable.Add(61, lab61Value2);
            _value2Hashtable.Add(62, lab62Value2);
            _value2Hashtable.Add(63, lab63Value2);
            _value2Hashtable.Add(64, lab64Value2);
            _value2Hashtable.Add(65, lab65Value2);
            _value2Hashtable.Add(66, lab66Value2);
            _value2Hashtable.Add(67, lab67Value2);
            _value2Hashtable.Add(68, lab68Value2);
            _value2Hashtable.Add(69, lab69Value2);
            _value2Hashtable.Add(70, lab70Value2);
            _value2Hashtable.Add(71, lab71Value2);
            _value2Hashtable.Add(72, lab72Value2);
            _value2Hashtable.Add(73, lab73Value2);
            _value2Hashtable.Add(74, lab74Value2);
            _value2Hashtable.Add(75, lab75Value2);
            _value2Hashtable.Add(76, lab76Value2);
            _value2Hashtable.Add(77, lab77Value2);
            _value2Hashtable.Add(78, lab78Value2);
            _value2Hashtable.Add(79, lab79Value2);
            _value2Hashtable.Add(80, lab80Value2);
            _value2Hashtable.Add(81, lab81Value2);
            _value2Hashtable.Add(82, lab82Value2);
            _value2Hashtable.Add(83, lab83Value2);
            _value2Hashtable.Add(84, lab84Value2);
            _value2Hashtable.Add(85, lab85Value2);
            _value2Hashtable.Add(86, lab86Value2);
            _value2Hashtable.Add(87, lab87Value2);
            _value2Hashtable.Add(88, lab88Value2);
            _value2Hashtable.Add(89, lab89Value2);
            _value2Hashtable.Add(90, lab90Value2);
            _value2Hashtable.Add(91, lab91Value2);
            _value2Hashtable.Add(92, lab92Value2);
            _value2Hashtable.Add(93, lab93Value2);
            _value2Hashtable.Add(94, lab94Value2);
            _value2Hashtable.Add(95, lab95Value2);
            _value2Hashtable.Add(96, lab96Value2);
            _value2Hashtable.Add(97, lab97Value2);
            _value2Hashtable.Add(98, lab98Value2);
            _value2Hashtable.Add(99, lab99Value2);
            _value2Hashtable.Add(100, lab100Value2);
            _value2Hashtable.Add(101, lab101Value2);
            _value2Hashtable.Add(102, lab102Value2);
            _value2Hashtable.Add(103, lab103Value2);
            _value2Hashtable.Add(104, lab104Value2);
            _value2Hashtable.Add(105, lab105Value2);
            _value2Hashtable.Add(106, lab106Value2);
            _value2Hashtable.Add(107, lab107Value2);
            _value2Hashtable.Add(108, lab108Value2);
            _value2Hashtable.Add(109, lab109Value2);
            _value2Hashtable.Add(110, lab110Value2);
            _value2Hashtable.Add(111, lab111Value2);
            _value2Hashtable.Add(112, lab112Value2);
            _value2Hashtable.Add(113, lab113Value2);
            _value2Hashtable.Add(114, lab114Value2);
            _value2Hashtable.Add(115, lab115Value2);
            _value2Hashtable.Add(116, lab116Value2);
            _value2Hashtable.Add(117, lab117Value2);
            _value2Hashtable.Add(118, lab118Value2);
            _value2Hashtable.Add(119, lab119Value2);
            _value2Hashtable.Add(120, lab120Value2);
            _value2Hashtable.Add(121, lab121Value2);
            _value2Hashtable.Add(122, lab122Value2);
            _value2Hashtable.Add(123, lab123Value2);
            _value2Hashtable.Add(124, lab124Value2);
            _value2Hashtable.Add(125, lab125Value2);
            _value2Hashtable.Add(126, lab126Value2);
            _value2Hashtable.Add(127, lab127Value2);
            _value2Hashtable.Add(128, lab128Value2);
            _value2Hashtable.Add(129, lab129Value2);
            _value2Hashtable.Add(130, lab130Value2);
            _value2Hashtable.Add(131, lab131Value2);
            _value2Hashtable.Add(132, lab132Value2);
            _value2Hashtable.Add(133, lab133Value2);
            _value2Hashtable.Add(134, lab134Value2);
            _value2Hashtable.Add(135, lab135Value2);
            _value2Hashtable.Add(136, lab136Value2);
            _value2Hashtable.Add(137, lab137Value2);
            _value2Hashtable.Add(138, lab138Value2);
            _value2Hashtable.Add(139, lab139Value2);
            _value2Hashtable.Add(140, lab140Value2);
            _value2Hashtable.Add(141, lab141Value2);
        }
        #endregion //Init

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 站名 - label 对应关系保存在数据库的 tblConfig 表, Name为StationNO的行
        /// </remarks>
        private void FillStationName()
        {
            Hashtable ht = CZGRQRCApp.Default.DBI.ExecuteStationNODataTable();
            foreach (DictionaryEntry de in ht)
            {
                string station = de.Key.ToString();
                int no = (int)de.Value;
                this.SetStationName(no, station);
            }
            this.NameNOHashtable = ht;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGRGW_Load(object sender, EventArgs e)
        {
            //for (int i = 1; i < 50; i++)
            //{
            //    Label lbl = GetValue1Label(i);
            //    Label lbl2 = GetValue2Label(i);
            //    lbl.Text = i.ToString();
            //    lbl2.Text = i.ToString();
            //}
            RefreshStatus();
            RefreshDatas();
        }



        #region StationIDMap
        /// <summary>
        /// 
        /// </summary>
        public Hashtable NameNOHashtable
        {
            get { return _nameNOHashtable; }
            set { _nameNOHashtable = value; }
        } private Hashtable _nameNOHashtable = new Hashtable();
        #endregion //StationIDMap

        /// <summary>
        /// 
        /// </summary>
        /// <param name="no"></param>
        /// <param name="value"></param>
        public void SetStationName(int no, string value)
        {
            Label lbl = GetNameLabel(no);
            if (lbl != null)
            {
                lbl.Text = value;
            }
            //if( value == "水务局东")
            //{
            //    int b=0;
            //}
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //private ComparatorCollection ComparatorCollection
        //{
        //    get { return CZGRQRCApp.Default.ComparatorCollection; }
        //}

        /// <summary>
        /// 
        /// </summary>
        private Renderer Renderer
        {
            get { return CZGRQRCApp.Default.Renderer; }
        }

        /// <summary>
        /// 
        /// </summary>
        private ColorConfig ColorConfig
        {
            get { return Config.Default.ColorConifg; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetValue1(string name, string value)
        {
            int no = GetNameNO(name);
            Label valueLabel = GetValue1Label(no);
            if (valueLabel != null)
            {
                valueLabel.Text = value;
                string compareName = GetValue1Name();
                Render(valueLabel, compareName, value);
            }

            //Comparator c = ComparatorCollection.GetComparator( compareName );
            //if (c != null)
            //{
            //    float val = float.Parse(value);
            //    CompareResult cr = c.Compare(val);
            //    Renderer.Render(new ControlBackForeColor(valueLabel), cr, this.ColorConfig);
            //}
            
            //Renderer renderer;
            //renderer.Render ( new ControlBackForeColor(valueLabel), cr, Config.Default.col
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueLabel"></param>
        /// <param name="valueName"></param>
        /// <param name="value"></param>
        private void Render(Label valueLabel, string valueName, string value)
        {
            AlarmDefineCollection cvs = CZGRQRCApp.Default.AlarmDefineCollection;
            AlarmDefine c = cvs.GetAlarmDefine(valueName);
            //Comparator c = ComparatorCollection.GetComparator( valueName );
            if (c != null)
            {
                float val = float.Parse(value);
                CompareResult cr = c.Compare(val);
                Renderer.Render(new ControlBackForeColor(valueLabel), cr, this.ColorConfig);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetValue2(string name, string value)
        {
            int no = GetNameNO(name);
            Label valueLabel = GetValue2Label(no);
            if (valueLabel != null)
            {
                valueLabel.Text = value;
                Render(valueLabel, GetValue2Name(), value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int GetNameNO(string name)
        {
            object obj = this.NameNOHashtable[name];
            if (obj != null)
            {
                return (int)obj;
            }
            else
            {
                return -1;
            }
            //throw new ArgumentException(name);
        }

        /// <summary>
        /// 根据编号获取名称Label, 如果没有对应的编号返回null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Label GetNameLabel(int no)
        {
            object obj = this._nameHashtable[no];
            if (obj != null)
            {
                return (Label)obj;
            }
            //
            //throw new ArgumentException(no.ToString());
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private Label GetValue1Label(int no)
        {
            object obj = this._value1Hashtable[no];
            return obj as Label;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private Label GetValue2Label(int no)
        {
            object obj = this._value2Hashtable[no];
            return obj as Label;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnT1_Click(object sender, EventArgs e)
        {

            using (new CP.Windows.Forms.WaitCursor())
            {
                this.CurrentValueType = ValueType.T1;
                RefreshStatus();
                RefreshDatas();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshDatas()
        {
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteGRLastDataTable();
            //StationNameFilter.Default.Process(tbl);

            foreach (DataRow row in tbl.Rows)
            {
                string name = row["StationName"].ToString();
                string value1 = GetValue1(row);
                string value2 = GetValue2(row);
                SetValue1(name, value1);
                SetValue2(name, value2);
            }
            this._t.Last = DateTime.Now;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="oot"></param>
        /// <returns></returns>
        private string GetValue1Name()
        {
            return "G" + this.CurrentValueType;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oot"></param>
        /// <returns></returns>
        private string GetValue2Name()
        {
            return "B" + this.CurrentValueType;
        }

        private string FloatFormat
        {
            get { return string.Format("F{0}", Config.Default.Digits); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetValue2(DataRow row)
        {
            string n = GetValue2Name();
            string v = row[n].ToString();
            float f = float.Parse(v);
            v = f.ToString(this.FloatFormat);
            return v;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetValue1(DataRow row)
        {
            string n = GetValue1Name();
            string v = row[n].ToString();
            float f = float.Parse(v);
            v = f.ToString(this.FloatFormat);
            return v;
        }

        /// <summary>
        /// 
        /// </summary>
        private ValueType CurrentValueType
        {
            get {return _currentValueType;}
            set {_currentValueType = value;}
        }private ValueType _currentValueType = ValueType.T1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnT2_Click(object sender, EventArgs e)
        {
            using (new CP.Windows.Forms.WaitCursor())
            {
                this.CurrentValueType = ValueType.T2;
                RefreshStatus();
                RefreshDatas();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnP1_Click(object sender, EventArgs e)
        {
            using (new CP.Windows.Forms.WaitCursor())
            {
                this.CurrentValueType = ValueType.P1;
                RefreshStatus();
                RefreshDatas();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnP2_Click(object sender, EventArgs e)
        {
            using (new CP.Windows.Forms.WaitCursor())
            {
                this.CurrentValueType = ValueType.P2;
                RefreshStatus();
                RefreshDatas();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshStatus()
        {
            string s = string.Format("{0} 单位:{1}",
                GetCurrentSelectedValueText(), 
                GetCurrentSelectedValueUnit());
            this.lblStatus.Text = s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetCurrentSelectedValueText()
        {
            Hashtable ht = new Hashtable();
            ht.Add(ValueType.T1, "一次温度");
            ht.Add(ValueType.T2, "二次温度");
            ht.Add(ValueType.P1, "一次压力");
            ht.Add(ValueType.P2, "二次压力");

            return ht[CurrentValueType].ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetCurrentSelectedValueUnit()
        {
            Hashtable ht = new Hashtable();
            ht.Add(ValueType.T1, "℃");
            ht.Add(ValueType.T2, "℃");
            ht.Add(ValueType.P1, "MPa");
            ht.Add(ValueType.P2, "MPa");
            return ht[CurrentValueType].ToString();

        }

        private T _t;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_t.IsTimeOut())
            {
                RefreshDatas();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    foreach (Control c in this.panel1.Controls)
        //    {
        //        if (c.Text == "100V1")
        //        {
        //            MessageBox.Show("find");
        //            c.BackColor = Color.Red;
        //        }
        //    }
        //}
    }
}
