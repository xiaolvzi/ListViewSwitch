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
            List<string> list = new List<string>();

            for (int i = 0; i < 30; i++)
            {
                list.Add(i + "");
            }
            adapter = new MyAdapter(this, list);
            mListView.Adapter = adapter;
            // we need to handle the layout Reuse question
            mListView.ItemClick += MListView_ItemClick; 

        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var ll = e.View as LinearLayout;
            var sw = ll.GetChildAt(1) as Switch;
            sw.Checked = true;
            adapter.changeState(e.Position);
        }

        class MyAdapter : BaseAdapter
        {
            Context mContext;
            List<string> mitems;
            List<int> mList;// this list is for store Switch's state, 0-off, 1-on
            public MyAdapter(Context context, List<string> list)
            {
                this.mContext = context;
                this.mitems = list;
                mList = new List<int>();
                for (int i = 0; i < mitems.Count; i++) {
                    mList.Add(0);
                }
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
                
                // init
                holder.txtDescription.Text = position + "";
                holder.ms.Focusable = false;

                if (mList[position] == 0)
                {
                    holder.ms.Checked = false;
                }
                else {
                    holder.ms.Checked = true;
                }
                
                return convertView;

            }

            internal void changeState(int position)
            {
                if (mList[position] == 1)
                {

                    mList[position] = 0;
                }
                else {
                    mList[position] = 1;
                }
                this.NotifyDataSetChanged();
            }
        }

        public class DataViewHolder : Java.Lang.Object
        {
            public LinearLayout ll { get; set; }
            public TextView txtDescription { get; set; }
            public Switch ms{ get; set; }

        }
    }
}

