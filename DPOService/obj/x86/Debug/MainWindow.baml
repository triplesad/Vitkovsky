   M S B A M L   `   `   `  ????E  ADPOService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DPOService
DPOService  5   	       DPOService.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'ucclr-namespace:DPOService     5   	   X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   -   5          ? Title$  
MainWindow??5	   	   $	??700??6   $
??1280??6)    ? WindowStartupLocation$ CenterScreen=?66    ? WindowStyle$
 None=?5
   	    ? AllowsTransparency . 
?????? .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $	??250 ?6   ?? 5      $??* ?6   .+?5   
   ??  ?? CornerRadius$ 	10 0 0 10??6   ??5      ?? 5       ?? 
StartPoint$ 0.5,0&?6&    ?? EndPoint$ 0.5,1&?69   .??5      ?  ? Color$ #f2f2f2??6#   	 ? Offset$	 0Q?63   ? 5      $ #e5e5e5??6#   $	 1Q?63   5      ._?5      ?? .+?5      ?? 
 ?? Orientation$
 
Horizontal=?6   $??Center=?66   $??0 35 0 0q?6S   .+?5      ?? $ 10??6   $	??150??6/   $	??150??6;   ._?5      ?? -   5         ??Name$
 Logo??5       $??/DPOLogo.png??6.   6D   5      5      ?? 5      $	??0.8??6   $??20 30q?6)   ???#99999968   	? 5         
menuButton#??[  6    d? 	IsChecked$
 TrueY?6B   .??5       ?? $
 
Horizontal=?6!   .+?5!      !  FontAwesome.Sharp.IconImage  ?  ?FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=?6'     menuButtonIcon#??[ 63   ?? 5"      $??Главная??6$     menuButtonText#??[ 63   5#      5$      	? 5%      #??[  6   .??5&      ?? $
 
Horizontal=?6!   .+?5'        $ ChartSimple=?6'   #??[ 6:   ?? 5(      $??Статистика??6$   #??[ 66   5)      5*      	? 5+      -   5         	?Name$ 
ExitButton??5+      #??[  62   .??5,      ?? $
 
Horizontal=?6!   .+?5-        $ RightFromBracket=?6'   #??[ 6?   ?? 5.      $??
Выход??6$   #??[ 61   5/      50      52      53      ?? 54   
   -   5        $??1??54      $ 	0 10 10 0??6!   ??55      ?? 56      $	 1,0&?6&   $	 0,1&?67   .??57      ? $ #f2f2f2??6#   $	 0Q?63   ? 58      $ #e5e5e5??6#   $	 1Q?63   59      ._?5<      ?  ? RowDefinitions 5=      ?? 5>      $
??auto ?6$   ?? 5?      $	??200 ?6$   ?? 5@      $??* ?6$   .+?5C      ?? $
 
Horizontal=?6   $??Bottom=?66   $??Right=?6Q   $??	0 0 30 20q?6m   5E      ? 5F      $??1??6   $??50 20 15 40q?6$    5H      ?? 5I      $??* ?6+   ?? 5J      $??* ?6+   ?? 5K      $??* ?6+   .+?5N         DPOService.Cards  $??0??6      Title$! Число клиентов??6/      Number$ 0??6F      Icon$
 User=?6Q      BackGround1$ #5b0f20??6]      BackGround2$ #cda1ab??6s      EllipseBackGround1$ #c08a97??6?      EllipseBackGround2$ #27060e??6?     5O      $??1??6   $  ??6/   $  ??68   $ #5b0f20??6C   $ #cda1ab??6Y   $ #c08a97??6p   $ #27060e??6?     5P      $??2??6   $  ??6/   $  ??68   $ #5b0f20??6C   $ #cda1ab??6Y   $ #c08a97??6p   $ #27060e??6?    J? Effect 5R      3  -System.Windows.Media.Effects.DropShadowEffect  5S         
BlurRadius$ 15Q?6+      	Direction$	 -90Q?6;      RenderingBias$ Quality=?6K      ShadowDepth$ 2Q?6c   5U      ? 5W      $??2??6   $??15 15 15 15q?6$   .+?5X      ?? ???#d9d9d9$ 15??62   ._?5Y      &   System.Windows.Controls.DataGrid  -   5          Name$ 	TabelMain??5Y   #      AutoGenerateColumns .  
?????? ??6R   ??    Columns 5Z      0  *System.Windows.Controls.DataGridTextColumn  5[   "   ,  &System.Windows.Controls.DataGridColumn   Header$ ID??65       Width5  /System.Windows.Controls.DataGridLengthConverter$  50 6A     5\   "   $ ФИО??65   $	  150 6B     5]   "   $! Номер телефона??65   $	  150 6M     5^   "   $, &Дата начала обучения??65   $	  150 6S     5_   "   $2 ,Дата окончания обучения??65   $	  150 6V   5b      5c      5d      5e      5f      5g      5h      