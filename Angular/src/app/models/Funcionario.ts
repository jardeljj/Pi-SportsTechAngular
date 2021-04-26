export class Funcionario{

    /**
     *
     */
    constructor() {
        this.id = 0;
        this.nome = '';
        this.departamentoId = 0;
        this.foto = '';
        this.rg = '';
    }

    public id: number;
    public nome: string;
    public foto: string;
    public rg: string;
    public departamentoId: number;
}