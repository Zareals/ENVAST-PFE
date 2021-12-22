using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BookManager : MonoBehaviour
{
    public List<Books> books;

    [SerializeField] Image bookCover;
    [SerializeField] TMP_Text author;
    [SerializeField] TMP_Text bookName;
    [SerializeField] TMP_Text body;

    public GameObject Selection;

    public void SelectBook(int BookId)
    {
        bookCover.sprite = books[BookId].Cover;
        author.text = books[BookId].Author;
        bookName.text = books[BookId].Name;
        body.text = books[BookId].Body;

        Selection.SetActive(false);
    }

    public void SelectionMenu()
    {
        Selection.SetActive(true);
    }
}

[System.Serializable]
public class Books
{
    public string Author;
    public string Name;
    public string Body;
    public Sprite Cover;
}
