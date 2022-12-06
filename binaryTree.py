class Node():

	# cuando el nodo recién se crea, sólo se puede inferir su peso
	# los demás atributos se establecen como None o False
	def __init__(self, value = None, left = None, right = None, parent = None, isRoot = False, isLeft = False, isRight = False, height = 1):
		self.value = value
		self.left = left
		self.right = right
		self.parent = parent
		self.isRoot = isRoot
		self.isLeft = isLeft
		self.isRight = isRight
		self.height = height

	# para contar el número de hijos que tiene una nodo padre
	def sonCount(self, root):
		x = 0
		# suma 1 al contador si encuentra hijos en la izquierda
		if root.left != None: x += 1
		# luego revisa en la derecha y hace lo mismo
		if root.right != None: x += 1
		return x

class BinarySearchTree():

	# cuando el árbol recién se crea, no tiene raíz ni peso
	def __init__(self, root = None, weight = 0):
		self.root = root
		self.weight = weight

	# regresa False si encuentra una raíz y True si no encuentra nada
	def empty(self):
		return self.root == None

	# encuentra la posición de un elemento
	def place(self, value):
		temp = self.root # atributo del arbol
		side = None
		while temp: # si temp tiene un valor
			prev = temp
			if value <= temp.value:
				temp = temp.left
				side = "left"
			else:
				temp = temp.right
				side = 'right'
		return (prev, side)
	
	# define el sucesor del nodo a borrar
	def successor(self, node):
		# el valor que buscamos borrar
		valueToDelete = node
		# hijo del valor a borrar
		nodeSon = valueToDelete.left
		# mientras nodeSon tenga valor
		while nodeSon:
			# el valor a borrar ahora es el hijo
			valueToDelete = nodeSon
			# el hijo se recorre al apuntador de la derecha
			nodeSon = nodeSon.right
		return valueToDelete

	# busca un nodo con el valor especificado
	def search(self, value, node):
		if node:
			# si la raíz (node) equivale al valor dado (value), se regresa el mismo valor
			# node = dirección de memoria / node.value = valor del nodo
			if node.value == value: return node
			# si el valor es menor que la raíz, se desplaza a la izquierda y vuelve a buscar
			elif value <= node.value: return self.search(node.left, value)
			# el valor será mayor que la raíz, así que se desplaza a la derecha y vuelve a buscar
			else: return self.search(node.right, value)
		# si la raíz (node) no tiene valor, se regresa None
		else: return None

	# agrega valores al árbol
	def append(self, *values):
		for value in values:
			# si el árbol está vacío, el valor se agrega a la raíz
			if self.empty(): self.root = Node(value = value, isRoot = True)
			# si no, se asigna a la posición debida, según el valor dado y el de la raíz
			else:
				parentNode, side = self.place(value)
				if side == "left": parentNode.left = Node(value = value, parent = parentNode, isLeft = True)
				else: parentNode.right = Node(value = value, parent = parentNode, isRight = True)
			
	# borra valores del árbol
	def delete(self, *elements):
		for element in elements:
			# se encuentra el nodo con el valor deseado a borrar
			nodeToDelete = self.search(self.root, element)
			# se manda mensaje de error si el nodo no existe o no tiene valor
			if not nodeToDelete: print("El elemento no existe o el árbol está vacío")
			# si se trata de borrar la raíz y el peso es 1, en otras palabras, sería el único nodo en el árblo
			elif self.weight == 1:
				self.root = None
				self.weight -= 1
			else:
				# se encuentra la cantidad de hijos que tiene el nodo a borrar
				sonCount = nodeToDelete.sonCount(nodeToDelete)
				# si no tiene hijos
				if sonCount == 0:
					if nodeToDelete.isLeft: nodeToDelete.parent.left = None
					else: nodeToDelete.parent.right = None
					nodeToDelete = None
				# si tiene un hijo
				elif sonCount == 1:
					# si el hijo se encuentra a la izquierda
					if nodeToDelete.isLeft:
						# el padre del nodo a borrar se engancha a su hijo, sin importar el lado
						nodeToDelete.parent.left = nodeToDelete.left or nodeToDelete.right
						nodeToDelete.parent.left.parent = nodeToDelete.parent
						# se modifican los atributos necesarios según la posición del nodo
						nodeToDelete.parent.left.isLeft = False
						nodeToDelete.parent.left.isRight = True
					# si el hijo se encuentra a la derecha
					else:
						# el padre del nodo a borrar se engancha a su hijo, sin importar el lado
						nodeToDelete.parent.right = nodeToDelete.left or nodeToDelete.right
						nodeToDelete.parent.right.parent = nodeToDelete.parent
						# se modifican los atributos necesarios según la posición del nodo
						nodeToDelete.parent.right.isLeft = True
						nodeToDelete.parent.right.isRight = False
					nodeToDelete = None
				# si tiene 2 hijos
				else:
					# se encuentra el sucesor
					successor = self.successor(nodeToDelete)
					# se guarda el valor en una variable temporal
					temp = successor.value
					# se borra el sucesor
					self.delete(successor.value)
					# el valor del nodo a borrar se reemplaza por el valor temporal
					nodeToDelete.value = temp
					# se borra la variable temporal
					temp = None
				# una vez que se haya borrado el nodo, se le resta 1 al peso del árbol
				self.weight -= 1

	# imprime en diferentes órdenes según el número que se indica
	def print(self, order = 0, node = "empty"):
		# si no se define desde dónde imprimir, se empezará desde la raíz
		if node == "empty": node = self.root
		# si el nodo dado tiene valor (no es None)
		if node:
			# en orden: izquierda -> raíz -> derecha
			if order == 0:
				# se trata de pasar el hijo de la izquierda (si es que hay)
				self.print(0, node.left)
				# se imprime el nodo actual
				print(node.value, end = " -> ")
				# se trata de pasar el hijo de la derecha (si es que hay)
				self.print(0, node.right)
			# pre orden: raíz - izquierda - derecha
			elif order == 1:
				# se imprime el nodo actual
				print(node.value, end = " -> ")
				# se trata de pasar el hijo de la izquierda (si es que hay)
				self.print(1, node.left)
				# se trata de pasar el hijo de la derecha (si es que hay)
				self.print(1, node.right)
			# pos orden: izquierda -> derecha -> raíz
			elif order == 2: 
				# se trata de pasar el hijo de la izquierda (si es que hay)
				self.print(2, node.left)
				# se trata de pasar el hijo de la derecha (si es que hay)
				self.print(2, node.right)
				# se imprime el nodo actual
				print(node.value, end = " -> ")

				# https://drive.google.com/drive/folders/1Knp5ube4yJxpoDOifR8hlFzdHUBlyc-a?usp=sharing
				# Link del portafolio 