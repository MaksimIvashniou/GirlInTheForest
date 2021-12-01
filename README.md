Exercise:
Однажды в темно-темном лесу потерялась девочка. Размер леса – NxN. Ходит-ходит девочка по лесу со скоростью V в произвольном направлении, но найти край леса не может. Девочка просто хаотично двигается по лесу, и при этом кричит «Аууу» в надежде, что кто-нибудь её услышит. Известно, что по лесу также двигаются ещё несколько объектов со скоростью 2V – мама, папа, дедушка и бабушка девочки, их схему движения реализуйте самостоятельно. Если кто-нибудь их них услышит девочку (а услышать её могут, если между девочкой и слушателем не более 4ч квадратов леса), то девочка будет спасена. Если она самостоятельно достигнет края леса, то так-же будет спасена. 
Создайте программную систему, в которой реализуется данная ситуация, при этом желательно визуализировать процесс поиска (достаточно использовать псевдо-графику). Спасите девочку!

Task:
Use Interfaces, Events to solve a task.

My actions:
1. Create folder "Models". Add classes:
    1.1 Create Interface: IPerson
  Girl : IPerson
  Parent : IPerson
    1.2 Create Interface: IMap
  Map : IMap
2. Add class "Game". + Methods: Init(), Start().
...
Next (How?): How to take data from Map(size) to calculate random position of characters. OK, we create class with X and Y positions on the map for characters and this class is a middle layer. But how it display?
