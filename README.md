# origami
**Origami** is an Opus Magnum mod based off of the alternating group A_4. It takes the 12 elements and adds four glyphs that act as functions that transmute pairs into elements, as described below. Currently, neither glyphs nor atoms have names, but this will be changed/updated in the future. Glyphs A and B are based off of the [Cayley graph of the alternating group A_4](<https://upload.wikimedia.org/wikipedia/commons/thumb/8/8b/Alternating_group_4%3B_Cayley_table%3B_numbers.svg/960px-Alternating_group_4%3B_Cayley_table%3B_numbers.svg.png>) and Glyphs C and D are based off of various subgroups of A_4. The former two lose one (1) mass per operation while the latter two add one (1) mass per operation. Finally, we add an equivalent to Van Berlo's wheel and prove an Ex Nihilo construction of the elements.

# Atom List

{1, 3, 4, 7, 8, 11, 12, 15, 16, 19, 20, 23}. Will probably be given names eventually.

# Function List

A(f,g): (f,g) ↦ k where k is according to the [Cayley graph of the alternating group A_4](<https://upload.wikimedia.org/wikipedia/commons/thumb/8/8b/Alternating_group_4%3B_Cayley_table%3B_numbers.svg/960px-Alternating_group_4%3B_Cayley_table%3B_numbers.svg.png>)

B(f, g; h): (f, g, h) ↦ A(f,A(g,h))

C(f, g, h): (f, g, h) ↦ k where f, g, h are in {1, 7, 16, 23} and k is the element {1, 7, 16, 23} \ {f, g, h}. Example: C(1, 16, 23) = 7.

D(f, g): (f, g) ↦ k where f, g are in one of {1, 3, 4}, {1. 8, 12}, {1, 11, 19}, {1, 15, 20} and k is the third element of whatever set f, g match into. Example: D(1, 3) = 4, D(11, 19) = 1.

# Glyph list

A: takes f, g as inputs and outputs A(f, g).

B: takes f, g as inputs, h as a bowl, then outputs B(f, g; h).

C: takes f, g, h as bowls, outputs C(f, g, h).

D: takes f, g as bowls, outputs D(f, g).

# The Wheel

The wheel consists of the identity element (1), and elements 11 and 12 in the following arrangement:
<pre>
  11 12 
1       1
  12 11
</pre>
# Ex Nihilo

The minimal generating set for A_4 has size two, and thus we only need two non-identity elements to generate all of A_4, and thus all elements in this mod. We derive the following sequence to get to all major elements:

D(1, 11) = 19
D(1, 12) = 8
A(8, 19) = 20
A(19, 8) = 3
A(19, 20) = 16
A(20, 19) = 7

We then derive the rest of the elements

Identity:
A(7, 7) = 1 

Subgroup of type Z_2 x Z_2:
A(7, 16) = 23

Subgroups of type Z_3:

A(3, 3) = 4
A(19, 19) = 11
A(8, 8) = 12
A(20, 20) = 15
