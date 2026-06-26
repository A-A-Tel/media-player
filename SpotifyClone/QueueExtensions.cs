namespace SpotifyClone;

public static class QueueExtensions
{
    public static TQueueable DequeueRandom<TQueueable>(this Queue<TQueueable> queue)
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        int index = Random.Shared.Next(queue.Count);

        Queue<TQueueable> temp = new();
        TQueueable selected = default!;

        for (int i = 0; i < queue.Count + temp.Count; i++)
        {
            TQueueable item = queue.Dequeue();

            if (i == index)
            {
                selected = item;
            }
            else
            {
                temp.Enqueue(item);
            }
        }

        while (temp.Count > 0)
            queue.Enqueue(temp.Dequeue());

        return selected;
    }
}