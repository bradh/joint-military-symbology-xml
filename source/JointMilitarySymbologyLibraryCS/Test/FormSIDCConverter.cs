﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using JointMilitarySymbologyLibrary;

namespace Test
{
    public partial class FormSIDCConverter : Form
    {
        private Librarian _librarian;
        private Symbol _symbol;

        public FormSIDCConverter()
        {
            InitializeComponent();

            _librarian = new Librarian();
            _librarian.IsLogging = true;
        }

        private void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        private void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            Console.WriteLine("Unknown attribute " +
            attr.Name + "='" + attr.Value + "'");
        }
    
        // Update controls on the form

        private void updateC(string s)
        {
            text2525C.Text = s;
        }

        private void updateD(string s1, string s2)
        {
            text2525D_1.Text = s1;
            text2525D_2.Text = s2;
        }

        private void updateControls()
        {
            if (_symbol != null)
            {
                updateC(_symbol.LegacySIDC);
                updateD(_symbol.SIDC.PartAString, _symbol.SIDC.PartBString);

                switch (_symbol.SymbolStatus)
                {
                    case SymbolStatusEnum.statusEnumNew:
                        toolStripStatusLabel1.Text = "Symbol is new/introduced in 2525D";
                        break;
                    case SymbolStatusEnum.statusEnumOld:
                        toolStripStatusLabel1.Text = "Symbol is old (in 2525C) and in 2525D";
                        break;
                    case SymbolStatusEnum.statusEnumRetired:
                        toolStripStatusLabel1.Text = "Symbol has been retired from 2525";
                        break;
                }
            }
            else
            {
                updateC("");
                updateD("", "");

                toolStripStatusLabel1.Text = "Symbol is invalid or not found in the symbol library";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = listBox1.SelectedItem.ToString();

            string[] l = s.Split('\t');

            _symbol = _librarian.MakeSymbol("2525C", l[0]);

            updateControls();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string s = listBox2.SelectedItem.ToString();

            string[] l = s.Split('\t');
            string[] ll = l[0].Split(',');

            _symbol = _librarian.MakeSymbol(new SIDC(ll[0],ll[1]));

            updateControls();
        }
    }
}
