   M S B A M L   `   `   `  ����P  LEASYTools.AvalonEditB, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AvalonEditB.SearchAvalonEditB.Search  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089$    AvalonEditB.Search.SearchPanel  �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources   Key � Cursor �� Orientation �� Path �� UpdateSourceTrigger	 �� RelativeSource
 �� ValidationRules5  /System.Windows.Controls.ExceptionValidationRule � ToolTip   booleanToVisibilityConverter �� 	Converter d� 	IsChecked�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      +search clr-namespace:AvalonEditB.Search  5      %�  '         7  �� 5      "    6	   .�5      ��  � �� 5      �� 5      "   6    5      ���� 5	       booleanToVisibilityConverter  6%   5
      .R�5      �� $��PART_searchPanel��6   #��� ��6&   #��� ��6l   $��1q�6�   $��Right=�6�   $	��Top=�6�   $ Arrow��6�   ._�5      �� $ Vertical=�6   .+�5   	   ]� $��False��6   .+�5   
   �� $��PART_searchTextBox��6(   $
��Left=�6   $
|�True��6B   $	��300��6S   $��24��6b   $��4,4,4,4q�6q   $��2,2,8,2q�6�   $��0��6�   .��6�   .��6�   ��5      �� 5      $ SearchPattern�6   $ PropertyChanged=�6[   	 6)   �� *TemplatedParent+
 5        5      5      .��5      5      �� 5   
   $��Right=�6   $��20��6)   $��20��65   $��Right=�6@   $	��Top=�6\   $,��&search:SearchCommands.CloseSearchPanel��6t   $��Center=�5   
   $��Center=�6,   $|�False��6P   $��7��6b   .��5      F� +����        � z  z � z     �     z 	#��� ��6/   $	��1.2��6v   5      �� 5   
   $��Right=�6   $��3,3,13,3q�6)   $��24��6;   $��24��6G   $$��search:SearchCommands.FindNext��6R   $��4��6�    6{   �� *Localization.FindNextText+	 �� *TemplatedParent+.��5      �� $��16��6   $��16��6   $
��Fill=�6(   $��next.png��67   5      �� 5   
   $��Right=�6   $��3q�6(   $��24��63   $��24��6?   $(��"search:SearchCommands.FindPrevious��6J   $��3��6�    6w   �� *Localization.FindPreviousText+	 �� *TemplatedParent+.��5       �� $��16��6   $��16��6   $
��Fill=�6(   $��prev.png��67   5!      5$   
   ]� 5%   	   $��False��6   y�6)   �� *ShowReplace+	 �� *TemplatedParent+8   .+�5&   
   �� $��PART_replaceTextBox��6(   $
��Left=�6   $
|�True��6C   $	��300��6T   $��24��6c   $��4,4,4,4q�6r   $��2,2,8,2q�6�   $��1��6�   .��6�   ��5'      �� 5(      $ Replacement�6   $ PropertyChanged=�6Y   	 6'   �� *TemplatedParent+
 5)        5*      5,      .��5-      5.      �� 50   
   $��Right=�6   $��3,3,33,3q�6(   $��24��6:   $��24��6F   $&�� search:SearchCommands.ReplaceAll��6Q   $��6��6�    6|   �� *Localization.ReplaceAllText+	 �� *TemplatedParent+.��51      �� $��16��6   $��16��6   $
��Fill=�6(   $��replaceall.png��67   52      �� 53   
   $��Right=�6   $��3q�6(   $��24��63   $��24��6?   $'��!search:SearchCommands.ReplaceNext��6J   $��5��6�    6v   �� *Localization.ReplaceNextText+	 �� *TemplatedParent+.��54      �� $��16��6   $��16��6   $
��Fill=�6(   $��replacenext.png��67   55      56   
   �� 58   	   $ 
Horizontal=�6   $��Segoe UI)�6-   .+�59   
   �� $��6,3,6,3q�6    6$   �� *	MatchCase+	 �� *TemplatedParent+��6u   �� *Localization.MatchCaseText+	 �� *TemplatedParent+�� 5:   
   $��6,3,6,3q�6    6$   �� *
WholeWords+	 �� *TemplatedParent+��6v   �� *" Localization.MatchWholeWordsText+	 �� *TemplatedParent+�� 5;   
   $��6,3,6,3q�6    6$   �� *
UseRegex+	 �� *TemplatedParent+��6t   �� *Localization.UseRegexText+	 �� *TemplatedParent+5<   
   5=   	   5>      5?      5A      5B      5C      