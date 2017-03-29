using System.Reflection;
using System.Runtime.InteropServices;
using Xamarin.Forms;
using Xamarin.Forms.Platform.LibUI;


[assembly: Dependency(typeof(SystemResourcesProvider))]

// Views

[assembly: ExportRenderer(typeof(Layout), typeof(LayoutRenderer))]
[assembly: ExportRenderer(typeof(Button), typeof(ButtonRenderer))]
[assembly: ExportRenderer(typeof(Entry), typeof(EntryRenderer))]
[assembly: ExportRenderer(typeof(ScrollView), typeof(ScrollViewRenderer))]

//ImageSources

//[assembly: ExportImageSourceHandler(typeof(FileImageSource), typeof(FileImageSourceHandler))]
//[assembly: ExportImageSourceHandler(typeof(StreamImageSource), typeof(StreamImagesourceHandler))]
//[assembly: ExportImageSourceHandler(typeof(UriImageSource), typeof(ImageLoaderSourceHandler))]

// Pages

[assembly: ExportRenderer(typeof(Page), typeof(PageRenderer))]

// Cells

//[assembly: ExportCell(typeof(Cell), typeof(TextCellRenderer))]
//[assembly: ExportCell(typeof(ImageCell), typeof(ImageCellRenderer))]
//[assembly: ExportCell(typeof(EntryCell), typeof(EntryCellRenderer))]
//[assembly: ExportCell(typeof(SwitchCell), typeof(SwitchCellRenderer))]
//[assembly: ExportCell(typeof(ViewCell), typeof(ViewCellRenderer))]
