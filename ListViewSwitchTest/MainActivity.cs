using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using Java.Lang;
using Android.Views;
using Android.Util;
using Android.Graphics;
using Android.Content;
using System;

namespace ListViewSwitchTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ListView mListView;
        MyAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            mListView = FindViewById<ListView>(Resource.Id.listview);
            List<MyData> list = new List<MyData>();

            for (int i = 0; i < 30; i++)
            {
                list.Add(new MyData(i+"",false));
            }
            adapter = new MyAdapter(this, list);
            mListView.Adapter = adapter;

        }
        

        class MyAdapter : BaseAdapter
        {
            Context mContext;
            List<MyData> mitems;
            public MyAdapter(Context context, List<MyData> list)
            {
                this.mContext = context;
                this.mitems = list;
               
            }
            public override int Count
            {
                get
                {
                    return mitems.Count;
                }
            }

            public override Java.Lang.Object GetItem(int position)
            {
                return mitems[position];
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                DataViewHolder holder = null;
                if (convertView == null)
                {
                    convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.item_layout, null, false);
                    holder = new DataViewHolder();
                    holder.ll = convertView.FindViewById<LinearLayout>(Resource.Id.ll);
                    holder.txtDescription= convertView.FindViewById<TextView>(Resource.Id.txtDescription);
                    holder.ms = convertView.FindViewById<Switch>(Resource.Id.sw);
                    convertView.Tag = holder;
                }
                else
                {
                    holder = convertView.Tag as DataViewHolder;

                }
                holder.ms.Tag = position;
                // init
                holder.txtDescription.Text = mitems[position].position;
                holder.ms.Checked = mitems[position].isCheck;
                holder.ms.CheckedChange+= Ms_CheckedChange;
                Log.Error("position : check", (int)holder.ms.Tag +" : "+ mitems[position].isCheck);
                return convertView;

            }

            private void Ms_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
            {
                var sm = sender as Switch;
                Log.Error("Ms_CheckedChange", (int)sm.Tag+"");
                if (e.IsChecked&&!mitems[(int)sm.Tag].isCheck)
                {
                    mitems[(int)sm.Tag].isCheck = true;
                    this.NotifyDataSetChanged();
                }
                else if(!e.IsChecked&& mitems[(int)sm.Tag].isCheck)
                {
                    mitems[(int)sm.Tag].isCheck = false;
                    this.NotifyDataSetChanged();
                }
               
            }

      
        }

        public class DataViewHolder : Java.Lang.Object
        {
            public LinearLayout ll { get; set; }
            public TextView txtDescription { get; set; }
            public Switch ms{ get; set; }

        }
        public class MyData:Java.Lang.Object {
            public MyData(string p,bool b) {
                this.position = p;
                this.isCheck = b;
            }
            public string position { get; set; }
            public bool isCheck { get; set; }
        }


    }
}

