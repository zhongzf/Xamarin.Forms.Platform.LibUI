using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Xamarin.Forms.Platform.LibUI.Interop
{
    public partial class NativeMethods
    {
        public const string LibUI = "libui";

        // This constant is provided because M_PI is nonstandard.
        // This comes from Go's math.Pi, which in turn comes from http://oeis.org/A000796.
        public const double uiPi = 3.14159265358979323846264338327950288419716939937510582097494459;

        // typedef struct uiInitOptions uiInitOptions;

        [StructLayout(LayoutKind.Sequential)]
        public struct uiInitOptions
        {
            public UIntPtr Size;
        };

        [DllImport(LibUI)] public static extern string uiInit(ref uiInitOptions options);
        [DllImport(LibUI)] public static extern void uiUninit();
        [DllImport(LibUI)] public static extern void uiFreeInitError(string err);

        [DllImport(LibUI)] public static extern void uiMain();
        [DllImport(LibUI)] public static extern void uiMainSteps();
        [DllImport(LibUI)] public static extern int uiMainStep(int wait);
        [DllImport(LibUI)] public static extern void uiQuit();

        public delegate void uiQueueMainDelegate(IntPtr data);
        [DllImport(LibUI)] public static extern void uiQueueMain(uiQueueMainDelegate f, IntPtr data);

        public delegate int uiOnShouldQuitDelegate(IntPtr data);
        [DllImport(LibUI)] public static extern void uiOnShouldQuit(uiOnShouldQuitDelegate f, IntPtr data);

        [DllImport(LibUI)] public static extern void uiFreeText(IntPtr text);

        // typedef struct uiControl uiControl;
        public delegate void uiControlDestroyDelegate(IntPtr c);
        public delegate UIntPtr uiControlHandleDelegate(IntPtr c);
        public delegate IntPtr uiControlParentDelegate(IntPtr c);
        public delegate void uiControlSetParentDelegate(IntPtr c1, IntPtr c2);
        public delegate int uiControlTopLevelDelegate(IntPtr c);
        public delegate int uiControlVisibleDelegate(IntPtr c);
        public delegate void uiControlShowDelegate(IntPtr c);
        public delegate void uiControlHideDelegate(IntPtr c);
        public delegate int uiControlEnabledDelegate(IntPtr c);
        public delegate void uiControlEnableDelegate(IntPtr c);
        public delegate void uiControlDisableDelegate(IntPtr c);

        [StructLayout(LayoutKind.Sequential)]
        public struct uiControl
        {
            public UInt32 Signature;
            public UInt32 OSSignature;
            public UInt32 TypeSignature;
            // void (*Destroy)(uiControl *);
            public uiControlDestroyDelegate Destroy;
            // uintptr_t (*Handle)(uiControl *);
            public uiControlHandleDelegate Handle;
            // uiControl *(*Parent)(uiControl *);
            public uiControlParentDelegate Parent;
            // void (*SetParent)(uiControl *, uiControl *);
            public uiControlSetParentDelegate SetParent;
            // int (*Toplevel)(uiControl *);
            public uiControlTopLevelDelegate TopLevel;
            // int (*Visible)(uiControl *);
            public uiControlVisibleDelegate Visible;
            // void (*Show)(uiControl *);
            public uiControlShowDelegate Show;
            // void (*Hide)(uiControl *);
            public uiControlHideDelegate Hide;
            // int (*Enabled)(uiControl *);
            public uiControlEnabledDelegate Enabled;
            // void (*Enable)(uiControl *);
            public uiControlEnableDelegate Enable;
            // void (*Disable)(uiControl *);
            public uiControlDisableDelegate Disable;
        };
        // TOOD add argument names to all arguments
        // #define uiControl(this) ((IntPtr c) (this))
        [DllImport(LibUI)] public static extern void uiControlDestroy(IntPtr c);
        [DllImport(LibUI)] public static extern UIntPtr uiControlHandle(IntPtr c);
        [DllImport(LibUI)] public static extern IntPtr cuiControlParent(IntPtr c);
        [DllImport(LibUI)] public static extern void uiControlSetParent(IntPtr c1, IntPtr c2);
        [DllImport(LibUI)] public static extern bool uiControlToplevel(IntPtr c);
        [DllImport(LibUI)] public static extern bool uiControlVisible(IntPtr c);
        [DllImport(LibUI)] public static extern void uiControlShow(IntPtr c);
        [DllImport(LibUI)] public static extern void uiControlHide(IntPtr c);
        [DllImport(LibUI)] public static extern bool uiControlEnabled(IntPtr c);
        [DllImport(LibUI)] public static extern void uiControlEnable(IntPtr c);
        [DllImport(LibUI)] public static extern void uiControlDisable(IntPtr c);

        [DllImport(LibUI)] public static extern IntPtr cuiAllocControl(UIntPtr n, UInt32 OSsig, UInt32 typesig, string typenamestr);
        [DllImport(LibUI)] public static extern void uiFreeControl(IntPtr c);

        // TODO make sure all controls have these
        [DllImport(LibUI)] public static extern void uiControlVerifySetParent(IntPtr c1, IntPtr c2);
        [DllImport(LibUI)] public static extern int uiControlEnabledToUser(IntPtr c);

        [DllImport(LibUI)] public static extern void uiUserBugCannotSetParentOnToplevel(string type);

        // typedef struct uiWindow uiWindow;
        // #define uiWindow(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern string uiWindowTitle(IntPtr w);
        [DllImport(LibUI)] public static extern void uiWindowSetTitle(IntPtr w, string title);
        [DllImport(LibUI)] public static extern void uiWindowContentSize(IntPtr w, out int width, out int height);
        [DllImport(LibUI)] public static extern void uiWindowSetContentSize(IntPtr w, int width, int height);
        [DllImport(LibUI)] public static extern bool uiWindowFullscreen(IntPtr w);
        [DllImport(LibUI)] public static extern void uiWindowSetFullscreen(IntPtr w, bool fullscreen);
        public delegate void uiWindowOnContentSizeChangedDelegate(IntPtr w, IntPtr data);
        [DllImport(LibUI)] public static extern void uiWindowOnContentSizeChanged(IntPtr w, uiWindowOnContentSizeChangedDelegate f, IntPtr data);
        public delegate bool uiWindowOnClosingDelegate(IntPtr w, IntPtr data);
        [DllImport(LibUI)] public static extern void uiWindowOnClosing(IntPtr w, uiWindowOnClosingDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern bool uiWindowBorderless(IntPtr w);
        [DllImport(LibUI)] public static extern void uiWindowSetBorderless(IntPtr w, bool borderless);
        [DllImport(LibUI)] public static extern void uiWindowSetChild(IntPtr w, IntPtr cchild);
        [DllImport(LibUI)] public static extern bool uiWindowMargined(IntPtr w);
        [DllImport(LibUI)] public static extern void uiWindowSetMargined(IntPtr w, bool margined);
        [DllImport(LibUI)] public static extern IntPtr uiNewWindow(string title, int width, int height, bool hasMenubar);

        // typedef struct uiButton uiButton;
        // #define uiButton(this) ((uiButton *) (this))
        [DllImport(LibUI)] public static extern string uiButtonText(IntPtr b);
        [DllImport(LibUI)] public static extern void uiButtonSetText(IntPtr b, string text);
        public delegate void uiButtonOnClickedDelegate(IntPtr b, IntPtr data);
        [DllImport(LibUI)] public static extern void uiButtonOnClicked(IntPtr b, uiButtonOnClickedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern IntPtr uiNewButton(string text);

        // typedef struct uiBox uiBox;
        // #define uiBox(this) ((uiBox *) (this))
        [DllImport(LibUI)] public static extern void uiBoxAppend(IntPtr b, IntPtr cchild, bool stretchy);
        [DllImport(LibUI)] public static extern void uiBoxDelete(IntPtr b, int index);
        [DllImport(LibUI)] public static extern bool uiBoxPadded(IntPtr b);
        [DllImport(LibUI)] public static extern void uiBoxSetPadded(IntPtr b, bool padded);
        [DllImport(LibUI)] public static extern IntPtr uiNewHorizontalBox();
        [DllImport(LibUI)] public static extern IntPtr uiNewVerticalBox();

        // typedef struct uiCheckbox uiCheckbox;
        // #define uiCheckbox(this) ((uiCheckbox *) (this))
        [DllImport(LibUI)] public static extern string uiCheckboxText(IntPtr c);
        [DllImport(LibUI)] public static extern void uiCheckboxSetText(IntPtr c, string text);
        public delegate void uiCheckboxOnToggledDelegate(IntPtr c, IntPtr data);
        [DllImport(LibUI)] public static extern void uiCheckboxOnToggled(IntPtr c, uiCheckboxOnToggledDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern bool uiCheckboxChecked(IntPtr c);
        [DllImport(LibUI)] public static extern void uiCheckboxSetChecked(IntPtr c, bool @checked);
        [DllImport(LibUI)] public static extern IntPtr uiNewCheckbox(string text);

        // typedef struct uiEntry uiEntry;
        // #define uiEntry(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern string uiEntryText(IntPtr e);
        [DllImport(LibUI)] public static extern void uiEntrySetText(IntPtr e, string text);
        public delegate void uiEntryOnChangedDelegate(IntPtr f, IntPtr data);
        [DllImport(LibUI)] public static extern void uiEntryOnChanged(IntPtr e, uiEntryOnChangedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern bool uiEntryReadOnly(IntPtr e);
        [DllImport(LibUI)] public static extern void uiEntrySetReadOnly(IntPtr e, bool @readonly);
        [DllImport(LibUI)] public static extern IntPtr uiNewEntry();
        [DllImport(LibUI)] public static extern IntPtr uiNewPasswordEntry();
        [DllImport(LibUI)] public static extern IntPtr uiNewSearchEntry();

        // typedef struct uiLabel uiLabel;
        // #define uiLabel(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern string uiLabelText(IntPtr l);
        [DllImport(LibUI)] public static extern void uiLabelSetText(IntPtr l, string text);
        [DllImport(LibUI)] public static extern IntPtr uiNewLabel(string text);

        // typedef struct uiTab uiTab;
        // #define uiTab(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern void uiTabAppend(IntPtr t, string name, IntPtr cc);
        [DllImport(LibUI)] public static extern void uiTabInsertAt(IntPtr t, string name, int before, IntPtr cc);
        [DllImport(LibUI)] public static extern void uiTabDelete(IntPtr t, int index);
        [DllImport(LibUI)] public static extern int uiTabNumPages(IntPtr t);
        [DllImport(LibUI)] public static extern bool uiTabMargined(IntPtr t, int page);
        [DllImport(LibUI)] public static extern void uiTabSetMargined(IntPtr t, int page, bool margined);
        [DllImport(LibUI)] public static extern IntPtr uiNewTab();

        // typedef struct uiGroup uiGroup;
        // #define uiGroup(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern string uiGroupTitle(IntPtr g);
        [DllImport(LibUI)] public static extern void uiGroupSetTitle(IntPtr g, string title);
        [DllImport(LibUI)] public static extern void uiGroupSetChild(IntPtr g, IntPtr cc);
        [DllImport(LibUI)] public static extern bool uiGroupMargined(IntPtr g);
        [DllImport(LibUI)] public static extern void uiGroupSetMargined(IntPtr g, bool margined);
        [DllImport(LibUI)] public static extern IntPtr uiNewGroup(string title);

        // spinbox/slider rules:
        // setting value outside of range will automatically clamp
        // initial value is minimum
        // complaint if min >= max?

        // typedef struct uiSpinbox uiSpinbox;
        // #define uiSpinbox(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern int uiSpinboxValue(IntPtr s);
        [DllImport(LibUI)] public static extern void uiSpinboxSetValue(IntPtr s, int value);
        public delegate void uiSpinboxOnChangedDelegate(IntPtr s, IntPtr data);
        [DllImport(LibUI)] public static extern void uiSpinboxOnChanged(IntPtr s, uiSpinboxOnChangedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern IntPtr uiNewSpinbox(int min, int max);

        // typedef struct uiSlider uiSlider;
        // #define uiSlider(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern int uiSliderValue(IntPtr s);
        [DllImport(LibUI)] public static extern void uiSliderSetValue(IntPtr s, int value);
        public delegate void uiSliderOnChangedDelegate(IntPtr s, IntPtr data);
        [DllImport(LibUI)] public static extern void uiSliderOnChanged(IntPtr s, uiSliderOnChangedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern IntPtr uiNewSlider(int min, int max);

        // typedef struct uiProgressBar uiProgressBar;
        // #define uiProgressBar(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern int uiProgressBarValue(IntPtr p);
        [DllImport(LibUI)] public static extern void uiProgressBarSetValue(IntPtr p, int n);
        [DllImport(LibUI)] public static extern IntPtr uiNewProgressBar();

        // typedef struct uiSeparator uiSeparator;
        // #define uiSeparator(this) ((uiSeparator *) (this))
        [DllImport(LibUI)] public static extern IntPtr uiNewHorizontalSeparator();
        [DllImport(LibUI)] public static extern IntPtr uiNewVerticalSeparator();

        // typedef struct uiCombobox uiCombobox;
        // #define uiCombobox(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern void uiComboboxAppend(IntPtr c, string text);
        [DllImport(LibUI)] public static extern int uiComboboxSelected(IntPtr c);
        [DllImport(LibUI)] public static extern void uiComboboxSetSelected(IntPtr c, int n);
        public delegate void uiComboboxOnSelectedDelegate(IntPtr c, IntPtr data);
        [DllImport(LibUI)] public static extern void uiComboboxOnSelected(IntPtr c, uiComboboxOnSelectedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern IntPtr uiNewCombobox();

        // typedef struct uiEditableCombobox uiEditableCombobox;
        // #define uiEditableCombobox(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern void uiEditableComboboxAppend(IntPtr c, string text);
        [DllImport(LibUI)] public static extern string uiEditableComboboxText(IntPtr c);
        [DllImport(LibUI)] public static extern void uiEditableComboboxSetText(IntPtr c, string text);
        // TODO what do we call a function that sets the currently selected item and fills the text field with it? editable comboboxes have no consistent concept of selected item
        public delegate void uiEditableComboboxOnChangedDelegate(IntPtr c, IntPtr data);
        [DllImport(LibUI)] public static extern void uiEditableComboboxOnChanged(IntPtr c, uiEditableComboboxOnChangedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern IntPtr uiNewEditableCombobox();

        // typedef struct uiRadioButtons uiRadioButtons;
        // #define uiRadioButtons(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern void uiRadioButtonsAppend(IntPtr r, string text);
        [DllImport(LibUI)] public static extern int uiRadioButtonsSelected(IntPtr r);
        [DllImport(LibUI)] public static extern void uiRadioButtonsSetSelected(IntPtr r, int n);
        public delegate void uiRadioButtonsOnSelectedDelegate(IntPtr r, IntPtr data);
        [DllImport(LibUI)] public static extern void uiRadioButtonsOnSelected(IntPtr r, uiRadioButtonsOnSelectedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern IntPtr uiNewRadioButtons();

        // typedef struct uiDateTimePicker uiDateTimePicker;
        // #define uiDateTimePicker(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern IntPtr uiNewDateTimePicker();
        [DllImport(LibUI)] public static extern IntPtr uiNewDatePicker();
        [DllImport(LibUI)] public static extern IntPtr uiNewTimePicker();

        // TODO provide a facility for entering tab stops?
        // typedef struct uiMultilineEntry uiMultilineEntry;
        // #define uiMultilineEntry(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern string uiMultilineEntryText(IntPtr e);
        [DllImport(LibUI)] public static extern void uiMultilineEntrySetText(IntPtr e, string text);
        [DllImport(LibUI)] public static extern void uiMultilineEntryAppend(IntPtr e, string text);
        public delegate void uiMultilineEntryOnChangedDelegate(IntPtr e, IntPtr data);
        [DllImport(LibUI)] public static extern void uiMultilineEntryOnChanged(IntPtr e, uiMultilineEntryOnChangedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern bool uiMultilineEntryReadOnly(IntPtr e);
        [DllImport(LibUI)] public static extern void uiMultilineEntrySetReadOnly(IntPtr e, bool @readonly);
        [DllImport(LibUI)] public static extern IntPtr uiNewMultilineEntry();
        [DllImport(LibUI)] public static extern IntPtr uiNewNonWrappingMultilineEntry();

        // typedef struct uiMenuItem uiMenuItem;
        // #define uiMenuItem(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern void uiMenuItemEnable(IntPtr m);
        [DllImport(LibUI)] public static extern void uiMenuItemDisable(IntPtr m);
        public delegate void uiMenuItemOnClickedDelegate(IntPtr sender, IntPtr window, IntPtr data);
        [DllImport(LibUI)] public static extern void uiMenuItemOnClicked(IntPtr m, uiMenuItemOnClickedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern bool uiMenuItemChecked(IntPtr m);
        [DllImport(LibUI)] public static extern void uiMenuItemSetChecked(IntPtr m, bool @checked);

        // typedef struct uiMenu uiMenu;
        // #define uiMenu(this) ((IntPtr ) (this))
        [DllImport(LibUI)] public static extern IntPtr uiMenuAppendItem(IntPtr m, string name);
        [DllImport(LibUI)] public static extern IntPtr uiMenuAppendCheckItem(IntPtr m, string name);
        [DllImport(LibUI)] public static extern IntPtr uiMenuAppendQuitItem(IntPtr m);
        [DllImport(LibUI)] public static extern IntPtr uiMenuAppendPreferencesItem(IntPtr m);
        [DllImport(LibUI)] public static extern IntPtr uiMenuAppendAboutItem(IntPtr m);
        [DllImport(LibUI)] public static extern void uiMenuAppendSeparator(IntPtr m);
        [DllImport(LibUI)] public static extern IntPtr uiNewMenu(string name);

        [DllImport(LibUI)] public static extern string uiOpenFile(IntPtr parent);
        [DllImport(LibUI)] public static extern string uiSaveFile(IntPtr parent);
        [DllImport(LibUI)] public static extern void uiMsgBox(IntPtr parent, string title, string description);
        [DllImport(LibUI)] public static extern void uiMsgBoxError(IntPtr parent, string title, string description);

        // typedef struct uiArea uiArea;
        // typedef struct uiAreaHandler uiAreaHandler;
        // typedef struct uiAreaDrawParams uiAreaDrawParams;
        // typedef struct uiAreaMouseEvent uiAreaMouseEvent;
        // typedef struct uiAreaKeyEvent uiAreaKeyEvent;

        // typedef struct uiDrawContext uiDrawContext;

        public delegate void uiAreaHandlerDrawDelegate(IntPtr ah, IntPtr data, IntPtr adp);
        // TODO document that resizes cause a full redraw for non-scrolling areas; implementation-defined for scrolling areas
        public delegate void uiAreaHandlerMouseEventDelegate(IntPtr ah, IntPtr data, IntPtr ame);
        // TODO document that on first show if the mouse is already in the uiArea then one gets sent with left=0
        // TODO what about when the area is hidden and then shown again?
        public delegate void uiAreaHandlerMouseCrossedDelegate(IntPtr ah, IntPtr data, int left);
        public delegate void uiAreaHandlerDragBrokenDelegate(IntPtr ah, IntPtr data);
        public delegate int uiAreaHandlerKeyEventDelegate(IntPtr ah, IntPtr data, IntPtr ake);

        [StructLayout(LayoutKind.Sequential)]
        public struct uiAreaHandler
        {
            //void (* Draw) (uiAreaHandler*, IntPtr , uiAreaDrawParams*);
            public uiAreaHandlerDrawDelegate Draw;
            // TODO document that resizes cause a full redraw for non-scrolling areas; implementation-defined for scrolling areas
            //void (* MouseEvent) (uiAreaHandler*, IntPtr , uiAreaMouseEvent*);
            public uiAreaHandlerMouseEventDelegate MouseEvent;
            // TODO document that on first show if the mouse is already in the uiArea then one gets sent with left=0
            // TODO what about when the area is hidden and then shown again?
            //void (* MouseCrossed) (uiAreaHandler*, IntPtr , int left);
            public uiAreaHandlerMouseCrossedDelegate MouseCrossed;
            //void (* DragBroken) (uiAreaHandler*, IntPtr );
            public uiAreaHandlerDragBrokenDelegate DragBroken;
            //int (* KeyEvent) (uiAreaHandler*, IntPtr , uiAreaKeyEvent*);
            public uiAreaHandlerKeyEventDelegate KeyEvent;
        };

        // TODO RTL layouts?
        // TODO reconcile edge and corner naming
        public enum uiWindowResizeEdge
        {
            Left,
            Top,
            Right,
            Bottom,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            // TODO have one for keyboard resizes?
            // TODO GDK doesn't seem to have any others, including for keyboards...
            // TODO way to bring up the system menu instead?
        };

        // #define uiArea(this) ((uiArea *) (this))
        // TODO give a better name
        // TODO document the types of width and height
        [DllImport(LibUI)] public static extern void uiAreaSetSize(IntPtr a, int width, int height);
        // TODO uiAreaQueueRedraw()
        [DllImport(LibUI)] public static extern void uiAreaQueueRedrawAll(IntPtr a);
        [DllImport(LibUI)] public static extern void uiAreaScrollTo(IntPtr a, double x, double y, double width, double height);
        // TODO document these can only be called within Mouse() handlers
        // TODO should these be allowed on scrolling areas?
        // TODO decide which mouse events should be accepted; Down is the only one guaranteed to work right now
        // TODO what happens to events after calling this up to and including the next mouse up?
        // TODO release capture?
        [DllImport(LibUI)] public static extern void uiAreaBeginUserWindowMove(IntPtr a);
        [DllImport(LibUI)] public static extern void uiAreaBeginUserWindowResize(IntPtr a, uiWindowResizeEdge edge);
        [DllImport(LibUI)] public static extern IntPtr uiNewArea(IntPtr ah);
        [DllImport(LibUI)] public static extern IntPtr uiNewScrollingArea(IntPtr ah, int width, int height);

        [StructLayout(LayoutKind.Sequential)]
        public struct uiAreaDrawParams
        {
            public IntPtr Context;

            // TODO document that this is only defined for nonscrolling areas
            public double AreaWidth;
            public double AreaHeight;

            public double ClipX;
            public double ClipY;
            public double ClipWidth;
            public double ClipHeight;
        };

        // typedef struct uiDrawPath uiDrawPath;
        // typedef struct uiDrawBrush uiDrawBrush;
        // typedef struct uiDrawStrokeParams uiDrawStrokeParams;
        // typedef struct uiDrawMatrix uiDrawMatrix;

        // typedef struct uiDrawBrushGradientStop uiDrawBrushGradientStop;

        public enum uiDrawBrushType
        {
            Solid,
            LinearGradient,
            RadialGradient,
            Image,
        };

        public enum uiDrawLineCap
        {
            Flat,
            Round,
            Square,
        };

        public enum uiDrawLineJoin
        {
            Miter,
            Round,
            Bevel,
        };

        // this is the default for botoh cairo and Direct2D (in the latter case, from the C++ helper functions)
        // Core Graphics doesn't explicitly specify a default, but NSBezierPath allows you to choose one, and this is the initial value
        // so we're good to use it too!
        // #define uiDrawDefaultMiterLimit 10.0

        public enum uiDrawFillMode
        {
            Winding,
            Alternate,
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawMatrix
        {
            public double M11;
            public double M12;
            public double M21;
            public double M22;
            public double M31;
            public double M32;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawBrush
        {
            public uiDrawBrushType Type;

            // solid brushes
            public double R;
            public double G;
            public double B;
            public double A;

            // gradient brushes
            public double X0;      // linear: start X, radial: start X
            public double Y0;      // linear: start Y, radial: start Y
            public double X1;      // linear: end X, radial: outer circle center X
            public double Y1;      // linear: end Y, radial: outer circle center Y
            public double OuterRadius;     // radial gradients only
            public IntPtr Stops;
            public UIntPtr NumStops;
            // TODO extend mode
            // cairo: none, repeat, reflect, pad; no individual control
            // Direct2D: repeat, reflect, pad; no individual control
            // Core Graphics: none, pad; before and after individually
            // TODO cairo documentation is inconsistent about pad

            // TODO images

            // TODO transforms
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawBrushGradientStop
        {
            public double Pos;
            public double R;
            public double G;
            public double B;
            public double A;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawStrokeParams
        {
            public uiDrawLineCap Cap;
            public uiDrawLineJoin Join;
            // TODO what if this is 0? on windows there will be a crash with dashing
            public double Thickness;
            public double MiterLimit;
            public IntPtr Dashes;
            // TOOD what if this is 1 on Direct2D?
            // TODO what if a dash is 0 on Cairo or Quartz?
            public UIntPtr NumDashes;
            public double DashPhase;
        };

        [DllImport(LibUI)] public static extern IntPtr uiDrawNewPath(uiDrawFillMode fillMode);
        [DllImport(LibUI)] public static extern void uiDrawFreePath(IntPtr p);

        [DllImport(LibUI)] public static extern void uiDrawPathNewFigure(IntPtr p, double x, double y);
        [DllImport(LibUI)] public static extern void uiDrawPathNewFigureWithArc(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, int negative);
        [DllImport(LibUI)] public static extern void uiDrawPathLineTo(IntPtr p, double x, double y);
        // notes: angles are both relative to 0 and go counterclockwise
        // TODO is the initial line segment on cairo and OS X a proper join?
        // TODO what if sweep < 0?
        [DllImport(LibUI)] public static extern void uiDrawPathArcTo(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, int negative);
        [DllImport(LibUI)] public static extern void uiDrawPathBezierTo(IntPtr p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
        // TODO quadratic bezier
        [DllImport(LibUI)] public static extern void uiDrawPathCloseFigure(IntPtr p);

        // TODO effect of these when a figure is already started
        [DllImport(LibUI)] public static extern void uiDrawPathAddRectangle(IntPtr p, double x, double y, double width, double height);

        [DllImport(LibUI)] public static extern void uiDrawPathEnd(IntPtr p);

        [DllImport(LibUI)] public static extern void uiDrawStroke(IntPtr c, IntPtr path, IntPtr b, IntPtr p);
        [DllImport(LibUI)] public static extern void uiDrawFill(IntPtr c, IntPtr path, IntPtr b);

        // TODO primitives:
        // - rounded rectangles
        // - elliptical arcs
        // - quadratic bezier curves

        [DllImport(LibUI)] public static extern void uiDrawMatrixSetIdentity(IntPtr m);
        [DllImport(LibUI)] public static extern void uiDrawMatrixTranslate(IntPtr m, double x, double y);
        [DllImport(LibUI)] public static extern void uiDrawMatrixScale(IntPtr m, double xCenter, double yCenter, double x, double y);
        [DllImport(LibUI)] public static extern void uiDrawMatrixRotate(IntPtr m, double x, double y, double amount);
        [DllImport(LibUI)] public static extern void uiDrawMatrixSkew(IntPtr m, double x, double y, double xamount, double yamount);
        [DllImport(LibUI)] public static extern void uiDrawMatrixMultiply(IntPtr dest, IntPtr src);
        [DllImport(LibUI)] public static extern int uiDrawMatrixInvertible(IntPtr m);
        [DllImport(LibUI)] public static extern int uiDrawMatrixInvert(IntPtr m);
        [DllImport(LibUI)] public static extern void uiDrawMatrixTransformPoint(IntPtr m, ref double x, ref double y);
        [DllImport(LibUI)] public static extern void uiDrawMatrixTransformSize(IntPtr m, ref double x, ref double y);

        [DllImport(LibUI)] public static extern void uiDrawTransform(IntPtr c, IntPtr m);

        // TODO add a uiDrawPathStrokeToFill() or something like that
        [DllImport(LibUI)] public static extern void uiDrawClip(IntPtr c, IntPtr path);

        [DllImport(LibUI)] public static extern void uiDrawSave(IntPtr c);
        [DllImport(LibUI)] public static extern void uiDrawRestore(IntPtr c);

        // TODO manage the use of Text, Font, and TextFont, and of the uiDrawText prefix in general

        ///// TODO reconsider this
        // typedef struct uiDrawFontFamilies uiDrawFontFamilies;

        [DllImport(LibUI)] public static extern IntPtr uiDrawListFontFamilies();
        [DllImport(LibUI)] public static extern int uiDrawFontFamiliesNumFamilies(IntPtr ff);
        [DllImport(LibUI)] public static extern IntPtr uiDrawFontFamiliesFamily(IntPtr ff, int n);
        [DllImport(LibUI)] public static extern void uiDrawFreeFontFamilies(IntPtr ff);
        ///// END TODO

        // typedef struct uiDrawTextLayout uiDrawTextLayout;
        // typedef struct uiDrawTextFont uiDrawTextFont;
        // typedef struct uiDrawTextFontDescriptor uiDrawTextFontDescriptor;
        // typedef struct uiDrawTextFontMetrics uiDrawTextFontMetrics;

        public enum uiDrawTextWeight
        {
            Thin,
            UltraLight,
            Light,
            Book,
            Normal,
            Medium,
            SemiBold,
            Bold,
            UltraBold,
            Heavy,
            UltraHeavy,
        };

        public enum uiDrawTextItalic
        {
            Normal,
            Oblique,
            Italic,
        };

        public enum uiDrawTextStretch
        {
            UltraCondensed,
            ExtraCondensed,
            Condensed,
            SemiCondensed,
            Normal,
            SemiExpanded,
            Expanded,
            ExtraExpanded,
            UltraExpanded,
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawTextFontDescriptor
        {
            public string Family;
            public double Size;
            public uiDrawTextWeight Weight;
            public uiDrawTextItalic Italic;
            public uiDrawTextStretch Stretch;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawTextFontMetrics
        {
            public double Ascent;
            public double Descent;
            public double Leading;
            // TODO do these two mean the same across all platforms?
            public double UnderlinePos;
            public double UnderlineThickness;
        };

        [DllImport(LibUI)] public static extern IntPtr uiDrawLoadClosestFont(ref uiDrawTextFontDescriptor desc);
        [DllImport(LibUI)] public static extern void uiDrawFreeTextFont(IntPtr font);
        [DllImport(LibUI)] public static extern UIntPtr uiDrawTextFontHandle(IntPtr font);
        [DllImport(LibUI)] public static extern void uiDrawTextFontDescribe(IntPtr font, out uiDrawTextFontDescriptor desc);
        // TODO make copy with given attributes methods?
        // TODO yuck this name
        [DllImport(LibUI)] public static extern void uiDrawTextFontGetMetrics(IntPtr font, out uiDrawTextFontMetrics metrics);

        // TODO initial line spacing? and what about leading?
        [DllImport(LibUI)] public static extern IntPtr uiDrawNewTextLayout(string text, IntPtr defaultFont, double width);
        [DllImport(LibUI)] public static extern void uiDrawFreeTextLayout(IntPtr layout);
        // TODO get width
        [DllImport(LibUI)] public static extern void uiDrawTextLayoutSetWidth(IntPtr layout, double width);
        [DllImport(LibUI)] public static extern void uiDrawTextLayoutExtents(IntPtr layout, ref double width, ref double height);

        // and the attributes that you can set on a text layout
        [DllImport(LibUI)] public static extern void uiDrawTextLayoutSetColor(IntPtr layout, int startChar, int endChar, double r, double g, double b, double a);

        [DllImport(LibUI)] public static extern void uiDrawText(IntPtr c, double x, double y, IntPtr layout);

        public enum uiModifiers
        {
            Ctrl = 1 << 0,
            Alt = 1 << 1,
            Shift = 1 << 2,
            Super = 1 << 3,
        };

        // TODO document drag captures
        [StructLayout(LayoutKind.Sequential)]
        public struct uiAreaMouseEvent
        {
            // TODO document what these mean for scrolling areas
            public double X;
            public double Y;

            // TODO see draw above
            public double AreaWidth;
            public double AreaHeight;

            public int Down;
            public int Up;

            public int Count;

            public uiModifiers Modifiers;

            public ulong Held1To64;
        };

        public enum uiExtKey
        {
            Escape = 1,
            Insert,         // equivalent to "Help" on Apple keyboards
            Delete,
            Home,
            End,
            PageUp,
            PageDown,
            Up,
            Down,
            Left,
            Right,
            F1,         // F1..F12 are guaranteed to be consecutive
            F2,
            F3,
            F4,
            F5,
            F6,
            F7,
            F8,
            F9,
            F10,
            F11,
            F12,
            N0,         // numpad keys; independent of Num Lock state
            N1,         // N0..N9 are guaranteed to be consecutive
            N2,
            N3,
            N4,
            N5,
            N6,
            N7,
            N8,
            N9,
            NDot,
            NEnter,
            NAdd,
            NSubtract,
            NMultiply,
            NDivide,
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct uiAreaKeyEvent
        {
            public char Key;
            public uiExtKey ExtKey;
            public uiModifiers Modifier;

            public uiModifiers Modifiers;

            public int Up;
        };

        // typedef struct uiFontButton uiFontButton;
        // #define uiFontButton(this) ((uiFontButton *) (this))
        // TODO document this returns a new font
        [DllImport(LibUI)] public static extern IntPtr uiFontButtonFont(IntPtr b);
        // TOOD SetFont, mechanics
        public delegate void uiFontButtonOnChangedDelegate(IntPtr b, IntPtr data);
        [DllImport(LibUI)] public static extern void uiFontButtonOnChanged(IntPtr b, uiFontButtonOnChangedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern IntPtr uiNewFontButton();

        // typedef struct uiColorButton uiColorButton;
        // #define uiColorButton(this) ((uiColorButton *) (this))
        [DllImport(LibUI)] public static extern void uiColorButtonColor(IntPtr b, out double r, out double g, out double bl, out double a);
        [DllImport(LibUI)] public static extern void uiColorButtonSetColor(IntPtr b, double r, double g, double bl, double a);
        public delegate void uiColorButtonOnChangedDelegate(IntPtr b, IntPtr data);
        [DllImport(LibUI)] public static extern void uiColorButtonOnChanged(IntPtr b, uiColorButtonOnChangedDelegate f, IntPtr data);
        [DllImport(LibUI)] public static extern IntPtr uiNewColorButton();

        // typedef struct uiForm uiForm;
        // #define uiForm(this) ((uiForm *) (this))
        [DllImport(LibUI)] public static extern void uiFormAppend(IntPtr f, string label, IntPtr cc, bool stretchy);
        [DllImport(LibUI)] public static extern void uiFormDelete(IntPtr f, int index);
        [DllImport(LibUI)] public static extern bool uiFormPadded(IntPtr f);
        [DllImport(LibUI)] public static extern void uiFormSetPadded(IntPtr f, bool padded);
        [DllImport(LibUI)] public static extern IntPtr uiNewForm();

        public enum uiAlign
        {
            Fill,
            Start,
            Center,
            End,
        };

        public enum uiAt
        {
            Leading,
            Top,
            Trailing,
            Bottom,
        };

        // typedef struct uiGrid uiGrid;
        // #define uiGrid(this) ((uiGrid *) (this))
        [DllImport(LibUI)] public static extern void uiGridAppend(IntPtr g, IntPtr cc, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        [DllImport(LibUI)] public static extern void uiGridInsertAt(IntPtr g, IntPtr cc, IntPtr cexisting, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        [DllImport(LibUI)] public static extern bool uiGridPadded(IntPtr g);
        [DllImport(LibUI)] public static extern void uiGridSetPadded(IntPtr g, bool padded);
        [DllImport(LibUI)] public static extern IntPtr uiNewGrid();
    }
}