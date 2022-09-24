using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AnimatorHero))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public UnityAction<int> OnHealthChanged;
    public UnityAction<int> OnMoneyChanged;

    //Подправить код
    [SerializeField] private int _health;
    [SerializeField] private GameObject _shop;
    [SerializeField] private Image _nowEquipped;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Sprite _deathImage;

    private Weapon _currectWeapon;
    private SpriteRenderer _spriteRenderer;
    private AnimatorHero _animatorHero;
    private Animator _animator;
    private int _currectHealth;
    private int _countOfFirstAidKits = 2;
    private int _healthByFirstAidKit = 25;

    public int Money { get; private set; }

    public void ApplayDamage(int damage)
    {
        _currectHealth -= damage;
        _healthBar.ChangeHealth(_currectHealth, _health);

        if (_currectHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        OnMoneyChanged?.Invoke(Money);
    }

    public void BuyItem(Item item)
    {
        Money -= item.Price;
        OnMoneyChanged?.Invoke(Money);

        if (item.TryGetComponent(out FirstAidKit firstAidKit))
        {
            _countOfFirstAidKits++;
            OnHealthChanged?.Invoke(_countOfFirstAidKits);
        }
        else
        {
            _weapons.Add(item.GetComponent<Weapon>());
        }
    }

    private void Start()
    {
        ChangeWeapon(0);
        OnHealthChanged?.Invoke(_countOfFirstAidKits);
        OnMoneyChanged?.Invoke(Money);
        _currectHealth = _health;
        _currectWeapon = _weapons[0];
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animatorHero = GetComponent<AnimatorHero>();
    }

    private void Update()
    {
        if (Input.anyKeyDown == false)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWeapon(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeapon(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWeapon(2);

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_shop.activeSelf == false)
                _shop.SetActive(true);
            else
                _shop.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(_animatorHero.Shoot);
            _currectWeapon.Shoot(_shootPoint);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && _countOfFirstAidKits > 0 && _currectHealth < _health)
        {
            _countOfFirstAidKits--;
            _currectHealth += _healthByFirstAidKit;
            OnHealthChanged?.Invoke(_countOfFirstAidKits);
            _healthBar.ChangeHealth(_currectHealth, _health);
        }
    }

    private void ChangeWeapon(int pressedNumber)
    {
        if (_weapons.Count > pressedNumber)
        {
            _currectWeapon = _weapons[pressedNumber];
            _nowEquipped.sprite = _currectWeapon.GetComponent<Item>().Icon;
        }
    }

    private IEnumerator Die()
    {
        _animator.SetBool(_animatorHero.Die, true);
        yield return new WaitForSeconds(0.4f);
        _animator.enabled = false;
        _spriteRenderer.sprite = _deathImage;
        enabled = false;
    }
}
