



CREATE TABLE IF NOT EXISTS investidor(  Id          INTEGER 
                                                    NOT NULL
                                                    AUTOINCREMENT
                                                    PRIMARY KEY,
                                CPF                 TEXT
                                                    NOT NULL
                                                    COMMENT 'CPF',
                                nome                TEXT
                                                    NOT NULL
                                                    COMMENT 'Nome',
                                renda               DECIMAL(15,2)
                                                    DEFAULT 0.00
                                                    COMMENT 'Renda mensal',
                                aporteMensal        DECIMAL(15,2)
                                                    DEFAULT 0.00
                                                    COMMENT 'Aporte mensal',
                                dataInclusao        DATETIME 
                                                    DEFAULT CURRENT_TIMESTAMP);

CREATE INDEX idxInvestidor_CPF
    ON investidor( cpf );



CREATE TABLE contaAplicacao(    Id                  INT         
                                                    UNSIGNED
                                                    NOT NULL 
                                                    AUTOINCREMENT
                                                    PRIMARY KEY
                                                    COMMENT 'Chave primaria',
                                nrBanco             TEXT
                                                    NOT NULL
                                                    COMMENT 'No. do banco de acordo com a lista do BACEN',
                                banco               TEXT
                                                    NOT NULL
                                                    COMMENT 'Nome do banco',
                                nrAgencia           TEXT
                                                    NOT NULL
                                                    DEFAULT '0001'
                                                    COMMENT 'No. da Agência',
                                nrConta             TEXT
                                                    NOT NULL
                                                    COMMENT 'No. da conta da aplicação',
                                IdInvestidor        INTEGER
                                                    UNSIGNED,
                                dataInclusao        TEXT
                                                    DEFAULT CURRENT_TIMESTAMP,
                                FOREIGN KEY(IdInvestidor) REFERENCES investidor( IdInvestidor ));

CREATE INDEX idxContaAplic_BcoAgConta
    ON contaAplicacao( nrBanco, nrAgencia, nrConta );



