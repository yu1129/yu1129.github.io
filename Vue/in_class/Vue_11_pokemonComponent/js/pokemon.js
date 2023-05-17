// 放 vue
import PokemonCard from './card.js';

const pokemonRequestUrl = 'https://raw.githubusercontent.com/jacko1114/Homeworks/main/Pokemon/js/pokemons.json'
const app = new Vue({
    el: '#app',
    data: {
        pokemonData: {
            // 塞所有的pokemon
            pokemonArray: [],
            // 只塞需要出現在畫面上的pokemon
            cardArray: [],
            // 儲存要顯示在 modal 上的pokemon資料
            currentPokemon: {
                index: '',
                id: '',
                name: '',
                hp: '',
                attack: '',
                defense: '',
                sp_attack: '',
                sp_defense: '',
                speed: '',
                img: '',
                type: '',
                evolution: '',
                genus: '',
            }
        },
        headerSetting: {
            mainImg: './images/722.png',
            subImg: './images/bottomRight.png'
        },
        pageSetting: {
            // 紀錄第幾個寶可夢
            index: 0
        }
    },
    // 生命週期 - 掛載完成(可訪問DOM)
    mounted() {
        this.getPokemonData()
    },
    methods: {
        // 幫我把 pokemon data 抓回來
        getPokemonData() {
            axios.get(pokemonRequestUrl)
                .then((res) => {
                    this.pokemonData.pokemonArray =
                        res.data.map((item, index) => ({
                            index,
                            id: item.id.toString().padStart(3, '0'),
                            name: item.name.chinese,
                            hp: item.base.HP,
                            attack: item.base.Attack,
                            defense: item.base.Defense,
                            sp_attack: item.base["Sp_Attack"],
                            sp_defense: item.base["Sp_Defense"],
                            speed: item.base.Speed,
                            img: `https://assets.pokemon.com/assets/cms2/img/pokedex/detail/${item.id.toString().padStart(3, "0")}.png`,
                            type: item.type,
                            evolution: item.evolution,
                            genus: item.genus,
                        }))

                    console.log(this.pokemonData.pokemonArray)
                })
                .catch((error) => { console.log(error) })
        },
        addOneCard() {
            if (this.pageSetting.index >= this.pokemonData.pokemonArray.length - 1) return
            this.pokemonData.cardArray.push(this.pokemonData.pokemonArray[this.pageSetting.index])
            this.pageSetting.index++
        },
        removeOneCard() {
            if (this.pageSetting.index == 0) return
            this.pokemonData.cardArray.splice(this.pageSetting.index - 1, 1)
            this.pageSetting.index--
        },
        addAllCards() {
            this.pokemonData.cardArray = this.pokemonData.pokemonArray
            this.pageSetting.index = this.pokemonData.pokemonArray.length - 1
        },
        removeAllCards() {
            this.pokemonData.cardArray = []
            this.pageSetting.index = 0
        },
        showModalData(id) {
            this.pokemonData.currentPokemon =
                this.pokemonData.cardArray[id]
        }
    },
    components: {
        'pokemon': PokemonCard
    }
})