   M S B A M L   `   `   `  ����N  JMTYVahidGhaedsharaf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MTYVahidGhaedsharafMTYVahidGhaedsharaf  5   	   &     MTYVahidGhaedsharaf.PlayerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MTYVahidGhaedsharaf     5   	   -   5          � Title$  PlayerWindow��5   	   $	��450��6   $	��800��6+   
���/���.��5	      �  J� RenderTransformOrigin$ 0.448,0.481&�6   .+�5
   
   o� $	��Top=�6   .@�5      m� -   5         m�Name$ mnuFile��5      $��_File��6(   .@�5      m� -   5        $ mnuNew��5      $
��_New��6+   m� 5      -   5        $ mnuSave��5      $��_Save��6,   m� 5      -   5        $ mnuQuit��5       � Cursor$  ��6,   $
��Quit��66   6D   5      m� 5      -   5        $ mnuEdit��5      $��_Edit��6(   .@�5      m� -   5        $ 	mnuInsert��5      $��_Insert��6.   6?   m� 5      -   5        $ 	mnuUpdate��5      $��_Update��6.   6?   m� 5      -	   5        $ 	mnuDelete��5      $  ��6.   $��_Delete��68   6I   5      m� 5      -
   5        $ mnuHelp��5      $��_Help��6(   .@�5      �� $"��Vahid Ghaedsharaf /991576881��6   5      5      �� 5   
   -   5         ��Name$ 	lstPlayer��5      $��43,72,387,83q�6%   6;   �� 5   
   $��	Players :��6   $
��Left=�6$   $��	39,42,0,0q�6?   $	��Top=�6R   �� 5   
   $
��Name��6   $
��Left=�6   $��
438,86,0,0q�6:   $	��Top=�6N   $ 0.727,-1.058&�6f   �� 5   
   $��Match Played��6   $
��Left=�6'   $��438,118,0,0q�6B   $	��Top=�6W   $ 0.727,-1.058&�6o   �� 5   
   $	��Won��6   $
��Left=�6   $��440,152,0,0q�69   $	��Top=�6N   $ 0.727,-1.058&�6f   �� 5   
   $
��Lost��6   $
��Left=�6   $��440,186,0,0q�6:   $	��Top=�6O   $ 0.727,-1.058&�6g   �� 5   
   $��GoalsScored��6   $
��Left=�6&   $��438,222,0,0q�6A   $	��Top=�6V   $ 0.727,-1.058&�6n   �� 5    
   -   5         ��Name$ txtName��5       $
��Left=�6#   $��
527,90,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��120��6~   �� 5!   
   -   5        $ txtMatch��5!      $
��Left=�6$   $��527,122,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5"   
   -   5        $ txtWon��5"      $
��Left=�6"   $��527,158,0,0q�6=   $
 Wrap=�6R   $	��Top=�6f   $	��120��6~   �� 5#   
   -   5        $ txtLost��5#      $
��Left=�6#   $��527,194,0,0q�6>   $
 Wrap=�6S   $	��Top=�6g   $	��120��6   �� 5$   
   -   5        $ txtGoal��5$      $
��Left=�6#   $��527,228,0,0q�6>   $
 Wrap=�6S   $	��Top=�6g   $	��120��6   �� 5%   
   -   5         ��Name$ btnAdd��5%      $��Insert��6!   $
��Left=�62   $��502,308,0,0q�6M   $	��Top=�6b   $��50��6z   $��40��6�   6�   �� 5&   
   -   5        $ 	btnUpdate��5&      $��Update��6$   $
��Left=�65   $��578,308,0,0q�6P   $	��Top=�6e   $��50��6}   $��40��6�   6�   �� 5'   
   -   5        $ 	btnDelete��5'      $��Delete��6$   $
��Left=�65   $��652,308,0,0q�6P   $	��Top=�6e   $��50��6}   $��40��6�   6�   5)      5*      