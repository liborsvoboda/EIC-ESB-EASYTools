   M S B A M L   `   `   `  ���� J  FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  R NEASYTools.CrashReporter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:EASYTools.CrashReporterEASYTools.CrashReporter ,   &EASYTools.CrashReporter.wdoCrashReport   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     7local%clr-namespace:EASYTools.CrashReporter     -     � Title$  wdocrashReport��$	��450��$	��450��.���  � ColumnDefinitions �� $��10 � z� SharedSizeGroup$ A���� $��* ��� $��10 �$ A�� � RowDefinitions �� $��10 ��� $��4* ��� $��40 �.+��� $��1��$��1��.@��� $��General��.��'  !EASYTools.CrashReporter.ucGeneral  �� $��
Exceptions��.��*  $EASYTools.CrashReporter.ucExceptions  �� $��
Screenshot��.��*  $EASYTools.CrashReporter.ucScreenshot  � $��2��$��1�� �� $��5 �$ B���� $��* ��� $��* ��� $��* ��� $��* ��� $��5 �$ B��.+�� $��1��$��4�� �� $��5 �$ C���� $��* ��� $��5 �$ C���� $��* ��� $��5 �$ C���� $��* ��� $��5 �$ C���� $��* ��� $��5 �$ C���� $��* ��� $��5 �$ C��.+��� -   $��btnSendReport��$��1��$��76��$��34��$��0,0,0,3q�$
��Left=�$��Bottom=�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .    AccentedSquareButtonStyle#���    � ToolTip$ 	Send Mail��.����  �� Orientation$ 
Horizontal=�.+��� $��5,0,5,0q�$��Center=�$<��6/EASYTools.CrashReporter;component/Images/email_go.png���� $��0,0,5,0q�$��Center=�$
��Send���� -   $��btnSaveReport��$��3��$��76��$��34��$��0,0,0,3q�$
��Left=�$��Bottom=� . #���   $
 Save��.���� $ 
Horizontal=�.+��� $��5,0,5,0q�$��Center=�$;��5/EASYTools.CrashReporter;component/Images/save_as.png���� $��0,0,5,0q�$��Center=�$
��Save���� -   $��btnCopy��$��5��$��73��$��40��$��3,0,0,0q�$
��Left=�$��Bottom=� . #���   $
 Copy��.���� $ 
Horizontal=�.+��� $��2,0,5,0q�$��Center=�$;��5/EASYTools.CrashReporter;component/Images/copy-32.png���� $��0,0,5,0q�$��Center=�$
��Copy���� -   $��
btnAnnulla��$��7��$��74��$��40��$��3,0,0,0q�$
��Left=�$��Bottom=� . #���   $ Close��.���� $ 
Horizontal=�.+��� $��2,0,2,0q�$��Center=�$X��R/EASYTools.CrashReporter;component/Images/Folders-OS-Exit-Full-Screen-Metro-32.png���� $��0,0,2,0q�$��Center=�$��Close���� -   $��btnQuit��$��9��$��73��$��40��$��3,0,0,0q�$
��Left=�$��Bottom=� . #���   $
 Quit��.���� $ 
Horizontal=�.+��� $��2,0,5,0q�$��Center=�$=��7/EASYTools.CrashReporter;component/Images/logout-32.png���� $��0,0,5,0q�$��Center=�$
��Quit��