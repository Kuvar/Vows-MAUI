using Android.Views;
using Android.Widget;
using Android.Content;
using Microsoft.Maui.Platform;
using Android.Graphics.Drawables;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace VowsApp.Platforms.Android.Renderers
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer()
        {

        }
        public CustomShellRenderer(Context context) : base(context) { }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new BottomNavView(this, shellItem);
        }
    }

    public class BottomNavView : ShellBottomNavViewAppearanceTracker
    {
        private IShellContext _context;
        public BottomNavView(IShellContext context, ShellItem shellItem) : base(context, shellItem)
        {
        }

        public override void SetAppearance(Google.Android.Material.BottomNavigation.BottomNavigationView bottomView, IShellAppearanceElement appearance)
         {
            base.SetAppearance(bottomView, appearance);

            BottomNavigationMenuView bottomNavigationView = bottomView.GetChildAt(0) as BottomNavigationMenuView;
            IMenu menu = bottomView.Menu;
            var inflater = LayoutInflater.FromContext(bottomView.Context);
            for (int i = 0; i < bottomNavigationView.ChildCount; i++)
            {
                var item = bottomNavigationView.GetChildAt(i) as BottomNavigationItemView;
                var nbar = inflater.Inflate(Resource.Layout.item_bottom_navigation_bar, null, false);
                if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
                {
                    ((ImageView)nbar.FindViewById(Resource.Id.icon)).SetImageDrawable(menu.GetItem(i).Icon);
                    var title = menu.GetItem(i).TitleCondensedFormatted.ToString();
                    ((TextView)nbar.FindViewById(Resource.Id.title)).SetText(title, TextView.BufferType.Normal);
                    item.RemoveAllViews();
                    item.AddView(nbar);
                }
                else
                {
                    item.SetItemPaddingTop(30);
                    item.SetIconSize(45);
                }
                if (bottomNavigationView.SelectedItemId == item.Id)
                {

                    int[] colors = { new Color(248, 248, 255).ToInt(), new Color(248, 248, 255).ToInt()};

                    GradientDrawable backColor = new GradientDrawable(GradientDrawable.Orientation.TlBr, colors);
                    //backColor.SetCornerRadii(new float[] { 30, 16, 50, 16, 0, 0, 0, 0 });
                    backColor.SetCornerRadius(20);
                    //backColor.SetPadding(-20, 0, 0, 20);
                    //backColor.SetStroke(30, new Color());

                    int lineBottomOffset = 8;
                    int lineWidth = 8;
                    int itemHeight = bottomNavigationView.Height - lineBottomOffset;
                    int itemWidth = (bottomNavigationView.Width / bottomView.ChildCount);

                    GradientDrawable bottomLine = new GradientDrawable();
                    bottomLine.SetShape(ShapeType.Line);
                    //bottomLine.SetPadding(0,)
                    bottomLine.SetStroke(lineWidth, Color.FromArgb("#000000").ToPlatform());

                    var layerDrawable = new LayerDrawable(new Drawable[] { bottomLine, backColor });
                    if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
                    {
                        layerDrawable.SetLayerWidth(0, 230);
                        layerDrawable.SetLayerInset(0, 50, 100, 10, 0);
                        layerDrawable.SetPadding(0, -50, 0, 0);
                    }
                    else
                    {
                        layerDrawable.SetLayerWidth(0, 150);
                        layerDrawable.SetLayerInset(0, 30, 140, 30, 0);
                        layerDrawable.SetPadding(0, -50, 0, 0);
                    }
                    item.Background = layerDrawable;
                }
                else
                {
                    item.Background = null;
                }
            }
        }
    }
}
