# Benchmark: Stack vs Heap - Rendimiento Real

*Generado el 12/06/2026 00:48:54*

---

## Comparación de Rendimiento

Vamos a crear 10 millones de objetos y medir el tiempo.

### Test 1: Struct (Tipo de Valor)

```csharp
for (int i = 0; i < 10000000; i++)
{
    Coordenada c = new Coordenada { X = i, Y = i * 2 };
    int resultado = c.X + c.Y;
}
```
⏱️ **Tiempo: 73 ms**
📍 **Memoria: STACK** (asignación instantánea)

### Test 2: Class (Tipo de Referencia)

```csharp
for (int i = 0; i < 10000000; i++)
{
    Jugador j = new Jugador { Nombre = "Jugador" + i, Puntuacion = i * 2 };
    int resultado = j.Puntuacion + j.Puntuacion;
}
```
⏱️ **Tiempo: 374 ms**
📍 **Memoria: HEAP** (asignación + GC)

### Resultado

| Tipo | Tiempo | Memoria |
|------|--------|---------|
| Struct | 73 ms | Stack |
| Class | 374 ms | Heap |

🚀 **El struct fue 5.12x más rápido**

### ¿Por qué?
- El struct se asigna en el Stack (movimiento de puntero)
- La class se asigna en el Heap (búsqueda de espacio + GC)
- Con 10 millones de objetos, el GC trabaja mucho más


---

