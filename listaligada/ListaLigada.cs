using System;
using System.Collections.Generic;

namespace listaligada
{
    // Classe que representa um nó da lista
    public class NoLinstaLigada<Item> where Item : System.IComparable<Item>
    {
        public Item valor;											// Item
        public NoLinstaLigada<Item> proximo;                       	// Referência para o próximo nó

        // Construtor padrão do nó da lista
        public NoLinstaLigada()
        { }

        // Construtor de nó que permite argumentos de inicialização
        public NoLinstaLigada(Item valor, NoLinstaLigada<Item> proximo)
        {
            this.valor = valor;
            this.proximo = proximo;
        }
    }

    public class LinstaLigada<Item> where Item : System.IComparable<Item>
    {
        public NoLinstaLigada<Item> head;                                   // Nó "Head" da lista
        
        // Método que adiciona um item à lista
        public void Adiciona(Item valor)
        {
            this.head = new NoLinstaLigada<Item>(valor, this.head);
        }

        // Método que adiciona otra lista a lista atual (concatena listas)
        public void AdicionaLista(LinstaLigada<Item> lista)
        {
            NoLinstaLigada<Item> iterador = lista.head;
            
            while (iterador != null)                                        
            {
                this.Adiciona(iterador.valor);
                iterador = iterador.proximo;
            }
        }

        // Método que remove um item da lista
        public bool Remove(Item valor)
        {
            NoLinstaLigada<Item> iterador = this.head;
            NoLinstaLigada<Item> anterior = this.head;

            if (head.valor.CompareTo(valor) == 0)
            {
                this.head = this.head.proximo;
                return true;
            }
            while (iterador != null)
            {
                if (iterador.valor.CompareTo(valor) == 0)
                {
                    anterior.proximo = iterador.proximo;
                    return true;
                }
                anterior = iterador;
                iterador = iterador.proximo;
            }
            return false;
        }

        // Método que evazia a lista
        public void Limpar()
        {
            this.head = null;

        }

        // Método que verifica se um item está na lista
        public bool Contem(Item valor)
        {
            NoLinstaLigada<Item> iterador = this.head;
            while (iterador != null)
            {
                if (iterador.valor.CompareTo(valor) == 0)
                {
                    return true;
                }
                iterador = iterador.proximo;
            }
            return false;
        }

        // Método que obtém o número de itens na lista
        public int Tamanho()
        {
            int i = 0;
            NoLinstaLigada<Item> iterador = this.head;
            while (iterador != null)
            {
                i++;
                iterador = iterador.proximo;
            }
            return i;
        }

        // Método que busca o índice de um item na lista
        public int IndiceDe(Item valor)
        {
            int indice = 0;
            NoLinstaLigada<Item> iterador = this.head;
            if (iterador != null)
            {
                while (iterador != null)
                {
                    indice++;
                    if (iterador.valor.CompareTo(valor) == 0)
                    {
                        return ++indice;
                    }
                    iterador = iterador.proximo;
                }
                return -1;
            }
            throw new NullReferenceException();
        }

        // Método que busca um item na lista cuja posição é dada por um índice
        public Item ItemEm(int indice)
        {
			int i = this.Tamanho() - 1;
			NoLinstaLigada<Item> iterador = this.head;
			if (iterador != null)
            {
                if (indice > -1 & indice < this.Tamanho())
                {
                    while (i > indice)
                    {
                        iterador = iterador.proximo;
                        i--;
                    }
                }
                else
                    throw new IndexOutOfRangeException();
                return iterador.valor;
            }
            throw new NullReferenceException();
        }

    }

    // Classe Lista, ela contém um método estático de converção
    public class Lista
    {
        // Método que converte um vetor numa lista e retorna essa lista
        public static LinstaLigada<Item> ConverteEmLista<Item>(Item[] vetor) where Item : System.IComparable<Item>
        {
			LinstaLigada<Item> lista = null;
			if(vetor != null)
			{
				lista = new LinstaLigada<Item>();
				for (int i = 0; i < vetor.Length; i++)
				{
					lista.Adiciona(vetor[i]);
				}
			}
            return lista;
        }
    }
}
