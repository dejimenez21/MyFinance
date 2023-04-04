import React, { useState } from 'react';
import { Button, Form, Input, Modal } from 'semantic-ui-react';

interface Props {
  modalOpen: boolean;
  handleClose: () => void;
  handleSubmit: (expense: Expense) => void;
}

export interface Expense {
  id: string;
  amount: number;
  description: string;
  date: string;
}

const ExpenseForm = ({ modalOpen, handleClose, handleSubmit }: Props) => {
  const [expenseData, setExpenseData] = useState<Expense>({
    id: '',
    description: '',
    amount: 0,
    date: '',
  });

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>, data: any) => {
    const { name, value } = data;
    setExpenseData({ ...expenseData, [name]: name === 'amount' ? parseFloat(value) : value });
  };

  return (
    <Modal open={modalOpen} onClose={handleClose} closeIcon>
      <Modal.Header>Add Expense</Modal.Header>
      <Modal.Content>
        <Form>
          <Form.Field
            control={Input}
            label="Description"
            name="description"
            placeholder="Description"
            value={expenseData.description}
            onChange={handleChange}
          />
          <Form.Field
            control={Input}
            label="Amount"
            name="amount"
            placeholder="Amount"
            type="number"
            step="0.01"
            value={expenseData.amount}
            onChange={handleChange}
          />
          <Form.Field
            control={Input}
            label="Date"
            name="date"
            placeholder="Date"
            type="date"
            value={expenseData.date}
            onChange={handleChange}
          />
          <Button type="submit" color="teal" content="Submit" onClick={() => handleSubmit(expenseData)} />
        </Form>
      </Modal.Content>
    </Modal>
  );
};

export default ExpenseForm;