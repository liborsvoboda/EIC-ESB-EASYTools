   M S B A M L   `   `   `  ����  EASYTools.VNCClient*    $EASYTools.VNCClient.ConnectDialogWpf   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Enter VNC Host��5   	   $
��Auto��6    $
��Auto��6.   $��Center=�6;   $	��Top=�6X    � 
ResizeMode$ 	CanResize=�6p    � SizeToContent$ WidthAndHeight=�6�   .��5      � $��Center=�6   $	��Top=�6(    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��	OK_Button��5   V   $��OK��6   $��1��6   $��23��6.   $��Right=�6:   $��Center=�6g   $��75��6�   $��5,5,5,10q�6�   $��1��6�   {�.  6�   �� 5   
   -   5        $��Cancel_Button��5   {   $��Cancel��6   $��2��6"   $��1��62   $��23��6?   $��Center=�6K   $��	5,5,10,10q�6h   $��Center=�6�   $��75��6�   6�   �� 5   
   -   5        $��
VncHostBox��5   e   $��23��6(   $��Stretch=�64   $��	5,10,10,2q�6R   $��Center=�6w   $
��Auto��6�   $��1��6�   $��2��6�   �� 5   
   -   5        $��Password_Label��5   _   $��VNC Host��6   $��28��6#   $��Center=�6/   $��	10,10,5,2q�6L   $��Center=�6u   $��5,10,2,0q�6�   5      5      